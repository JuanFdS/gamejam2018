using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;


public class Player_Network_Unet : NetworkBehaviour {

    //[SerializeField]
    //Behaviour[] ComponentsToDisable;

    //public GameObject BodyCollider;
    
    //void Start()
    //{
    //    if (isServer)
    //    {
    //        weatherController = GameManager.singletone.Sun.GetComponent<DayNightAndWeatherController>();
    //    }
    //    if (!isLocalPlayer)
    //    {
    //        AssignLayer(this.gameObject, "RemotePlayer");
            
    //        if (transform.tag != "Raptor")
    //        {
    //            MarkerRadar.enabled = true;
    //            SetTagRecursively(BodyCollider, "Player", 0);
    //            Util.SetLayerRecursively(ItemCollider, LayerMask.NameToLayer("Ignore Raycast"));
    //        }
    //        else if (transform.tag == "Raptor" && GameManager.LocalPlayerCharacter == "Raptor")
    //        {
    //            MarkerRadar.enabled = true;
    //            GameManager.CantidadRaptors++;
    //            SetTagRecursively(BodyCollider, "Raptor");
    //        }
    //        else
    //        {
    //            MarkerRadar.enabled = false;
    //            GameManager.CantidadRaptors++;
    //            SetTagRecursively(BodyCollider, "Player", 0);
    //            Util.SetLayerRecursively(ItemCollider, LayerMask.NameToLayer("Ignore Raycast"));
    //        }
    //    }
    //    else
    //    {
    //        PlayerUI.InventoryParent.SetActive(true);
    //        AssignLayer(this.gameObject, "LocalPlayer");
    //        GameManager.LocalPlayerCharacter = transform.tag;
    //        GameManager.LocalPlayer = this.gameObject;
    //        SetRadarOnOff(true);

    //        GetComponent<PlayerUnet>().SetupPlayer();

    //        string _username = "loading...";
    //        if (userAccountManager.IsLoggedIn)
    //            _username = userAccountManager.loggedIn_Username;
    //        else
    //            _username = transform.name;

    //        GetComponent<PlayerUnet>().username = _username;
    //        CmdSetUsername(transform.name, _username);
            

    //        playerFirstCam.SetActive(true);
            
    //        PlayerUnet[] players = GameManager.GetAllPlayers();

    //        foreach (PlayerUnet player in players)
    //        {
                
    //            if (player.username != _username && player.tag != "Raptor")
    //            {
    //                player.ActivateTracker();
                    
    //            }
    //            else if (player.username != _username && player.tag == "Raptor" && transform.tag == "Raptor")
    //            {
    //                player.ActivateTracker();
    //            }

    //        }


    //        if (transform.tag == "Raptor")
    //        {
    //            PlayerUI.InventoryParent.SetActive(false);
    //            SetTagRecursively(BodyCollider, "LocalRaptor");
    //            GameManager.CantidadRaptors++;
                
    //            Util.SetLayerRecursively(playerGraphic, LayerMask.NameToLayer("DontDraw"));

                
    //        }
    //        else
    //        {
                
    //            SetTagRecursively(BodyCollider, "LocalPlayer");
                
    //            SetTagRecursively(ItemCollider, "Untagged");
    //            Util.SetLayerRecursively(ItemCollider , LayerMask.NameToLayer("Ignore Raycast"));
    //        }

            
    //        weatherController = GameManager.singletone.Sun.GetComponent<DayNightAndWeatherController>();
    //        if (weatherController != null)
    //            CmdGetServerTimeAndWeatherConditions();
    //        else
    //            Debug.LogError("No se ah encontrado el weather controller en el Objeto Sun");

    //    }
    //}
    
    
    
    //[Command]
    //void CmdGetServerTimeAndWeatherConditions()
    //{
    //    RpcSetLocalTimeAndWeatherFromServer(weatherController.currentCycleTime , DayNightAndWeatherController.currentPhase , weatherController.transform.position, weatherController.transform.rotation);
    //}

    //[ClientRpc]
    //void RpcSetLocalTimeAndWeatherFromServer(float ServerCycleTime, DayNightAndWeatherController.DayPhase ServerPhase, Vector3 sunPositionServer, Quaternion sunRotationServer)
    //{
    //    if (isLocalPlayer && !isServer)
    //    {
    //        weatherController.SetTimesToServerTime(ServerCycleTime, ServerPhase, sunPositionServer, sunRotationServer);
    //    }
    //}

    //[Command]
    //void CmdSetUsername (string playerID, string username)
    //{
    //    PlayerUnet player = GameManager.GetPLayer(playerID);
    //    if(player != null)
    //    {
    //        Debug.Log(username + " has joined!");
    //        player.username = username;
    //    }
    //}

    //public override void OnStartClient()
    //{
    //    base.OnStartClient();
    //    string _netID = GetComponent<NetworkIdentity>().netId.ToString();
    //    PlayerUnet player = GetComponent<PlayerUnet>();
    //    GameManager.RegisterPlayer(_netID, player);
        
        
    //    this.SendMessage("SetStartPosition", this.transform.position, SendMessageOptions.DontRequireReceiver);
    //    this.SendMessage("SetStartRotation", this.transform.rotation, SendMessageOptions.DontRequireReceiver);
    //}
    

    //void OnDisable()
    //{
    //    GameManager.UnregisterPlayer(transform.name);
    //    if (transform.tag == "Raptor")
    //    {
    //        GameManager.CantidadPajaros++;
    //    }
    //    if (hasAuthority)
    //        GameManager.singletone.CheckIfResetToHumanNeeded(transform.tag);
    //}

    //void DisableComponent()
    //{
    //    for (int i = 0; i < ComponentsToDisable.Length; i++)
    //    {
    //        ComponentsToDisable[i].enabled = false;
    //    }
    //}
    
}
