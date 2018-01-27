using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
//Server-authoritative movement with Client-side prediction and reconciliation
//Author:gennadiy.shvetsov@gmail.com
//QoS channels used:
//channel #0: Reliable Sequenced
//channel #1: Unreliable Sequenced
[NetworkSettings(channel=1,sendInterval=0.05f)]
public class NetworkMovementNico : NetworkBehaviour {
	//This struct would be used to collect player inputs
	public struct Inputs			
	{
		public float forward;
		public float sides;
		public float yaw;
		public float vertical;
		public float pitch;
		public bool sprint;
		public bool crouch;

	}

	public struct SyncInputs			
	{
		public sbyte forward;
		public sbyte sides;
		public float yaw;
		public sbyte vertical;
		public float pitch;
		public bool sprint;
		public bool crouch;
		
		public float timeStamp;
	}

	//This struct would be used to collect results of Move and Rotate functions
	public struct Results
	{
		public Quaternion rotation;
		public Vector3 position;
		public bool sprinting;
		public bool crouching;
		public float timeStamp;
	}

	public struct SyncResults
	{
		public ushort yaw;
		public ushort pitch;
		public Vector3 position;
		public bool sprinting;
		public bool crouching;
		public float timeStamp;
	}

    //Vector3 firstPosition = new Vector3(0,0,0);
	private Inputs _inputs;

	private Results _results;

	//Owner client and server would store it's inputs in this list
	//private List<Inputs> _inputsList = new List<Inputs>();
	//This list stores results of movement and rotation. Needed for non-owner client interpolation
	//private List<Results> _resultsList = new List<Results>();
	//Interpolation related variables
	private float _dataStep = 0;
	private bool _jumping = false;
	private Vector3 _startPosition;
	private Quaternion _startRotation;
    Vector3 lastPosition;
    Quaternion lastRotation;

    public void SetStartPosition(Vector3 position){
		_results.position = position;
        if (isLocalPlayer)
            Cmd_SendPosition(_results.position);
    }

	public void SetStartRotation(Quaternion rotation){
		_results.rotation = rotation;
        if (isLocalPlayer && !isServer)
            Cmd_SendRotation(_results.rotation);
        else if (isServer)
            RpcReceiveRotation(rotation);
    }
    void Update()
    {
        if (isLocalPlayer)
        {
            GetInputs(ref _inputs);
            //Client side prediction for non-authoritative client or plane movement and rotation for listen server/host
            lastPosition = _results.position;
            lastRotation = _results.rotation;
            bool lastCrouch = _results.crouching;
            _results.rotation = Rotate(_inputs, _results);
            _results.crouching = Crouch(_inputs, _results);
            _results.sprinting = Sprint(_inputs, _results);
            _results.position = Move(_inputs, _results);
            if (_dataStep >= GetNetworkSendInterval())
            {
                if (Vector3.Distance(_results.position, lastPosition) > 0 || Quaternion.Angle(_results.rotation, lastRotation) > 0 || _results.crouching != lastCrouch)
                {
                    if(Vector3.Distance(_results.position, lastPosition) > 0 && Quaternion.Angle(_results.rotation, lastRotation) > 0) 
                        {
                            Cmd_SendPositionAndRotation(_results.position, _results.rotation);
                        } 
                    else if (Vector3.Distance(_results.position, lastPosition) > 0)
                    {
                        Cmd_SendPosition(_results.position);
                    }
                    else
                    {
                        Cmd_SendRotation(_results.rotation);
                    }

                }
                _dataStep = 0;
            }
            _dataStep += Time.deltaTime;
        }
        else
        {
            LerpPosition();
        }
    }

    #region command
    [Command(channel = 1)]
    void Cmd_SendPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        RpcReceivePositionAndRotation(position, rotation);
    }
    [Command(channel = 1)]
    void Cmd_SendPosition(Vector3 position)
    {
        RpcReceivePosition(position);
    }
    [Command(channel = 1)]
    void Cmd_SendRotation(Quaternion rotation)
    {
        RpcReceiveRotation(rotation);
    }


    #endregion

    #region command
    [ClientRpc]
    void RpcReceivePositionAndRotation(Vector3 position, Quaternion rotation)
    {
        if (!isLocalPlayer)
        {
            UpdatePosition(position);
            UpdateRotation(rotation);
        }
    }
    [ClientRpc]
    void RpcReceivePosition(Vector3 position)
    {
        if (!isLocalPlayer)
        {
            UpdatePosition(position);
        }
    }
    [ClientRpc]
    void RpcReceiveRotation(Quaternion rotation)
    {
        if (!isLocalPlayer)
        {
            UpdateRotation(rotation);
        }
    }



    #endregion

    //Self explanatory
    //Can be changed in inherited class
    public virtual void GetInputs(ref Inputs inputs){
        //if (PauseMenu.IsOn)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    return;
        //}
            
        //if(Cursor.lockState != CursorLockMode.Locked)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //}


        //Don't use one frame events in this part
        //It would be processed incorrectly 
        inputs.sides = RoundToLargest(Input.GetAxis ("Horizontal"));
		inputs.forward = RoundToLargest(Input.GetAxis ("Vertical"));
		inputs.yaw = -Input.GetAxis("Mouse Y") * 100 * Time.fixedDeltaTime/Time.deltaTime;
		inputs.pitch = Input.GetAxis("Mouse X") * 100 * Time.fixedDeltaTime/Time.deltaTime;
		inputs.sprint = Input.GetButton ("Sprint");
		inputs.crouch = Input.GetButton ("Crouch");
		if (Input.GetButtonDown ("Jump") && inputs.vertical <=-0.9f) {
			_jumping = true;
		}
		float verticalTarget = -1;
		if (_jumping) {
			verticalTarget = 1;
			if(inputs.vertical >= 0.9f){
				_jumping = false;
			}
		}
		inputs.vertical = Mathf.Lerp (inputs.vertical, verticalTarget, 20 * Time.deltaTime);
	}
	
	sbyte RoundToLargest(float inp){
		if (inp > 0) {
			return 1;
		} else if (inp < 0) {
			return -1;
		}
		return 0;
	}

    //Next virtual functions can be changed in inherited class for custom movement and rotation mechanics
    //So it would be possible to control for example humanoid or vehicle from one script just by changing controlled pawn
    public virtual void LerpPosition()
    {
    }

    public virtual void UpdatePosition(Vector3 newPosition){
		transform.position = newPosition;
	}

	public virtual void UpdateRotation(Quaternion newRotation){
		transform.rotation = newRotation;
	}

	public virtual void UpdateCrouch(bool crouch){

	}

	public virtual void UpdateSprinting(bool sprinting){
		
	}

	public virtual Vector3 Move(Inputs inputs, Results current){
		transform.position = current.position;
		float speed = 3f;
		if (current.crouching) {
			speed = 2f;
		}
		if (current.sprinting) {
			speed = 6f;
		}
		transform.Translate (Vector3.ClampMagnitude(new Vector3(inputs.sides,inputs.vertical,inputs.forward),1) * speed * Time.deltaTime);
		return transform.position;
	}
	public virtual bool Sprint(Inputs inputs,Results current){
		return inputs.sprint;
	}

	public virtual bool Crouch(Inputs inputs,Results current){
		return inputs.crouch;
	}

	public virtual Quaternion Rotate(Inputs inputs, Results current){
		transform.rotation = current.rotation;
		float mHor = transform.eulerAngles.y + inputs.pitch * Time.deltaTime;
		float mVert = transform.eulerAngles.x + inputs.yaw * Time.deltaTime;
		
		if (mVert > 180)
			mVert -= 360;
		transform.rotation = Quaternion.Euler (mVert, mHor, 0);
		return transform.rotation;
	}
	
}
