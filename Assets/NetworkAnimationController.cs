using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAnimationController : MonoBehaviour {

    public Animator AnimationController;
    Vector3 previousPosition = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
        AnimationController = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(this.transform.position.x != previousPosition.x && Mathf.Abs(this.transform.position.y - previousPosition.y) < 0.01)
        {
            AnimationController.SetFloat("Speed", 1);
        }
        else
            AnimationController.SetFloat("Speed", 0);

        if(Mathf.Abs(this.transform.position.y - previousPosition.y) > 0.01)
        {
            AnimationController.SetFloat("vSpeed", 1);
        }
        else
            AnimationController.SetFloat("vSpeed", 0);

        previousPosition = this.transform.position;

    }
    
}
