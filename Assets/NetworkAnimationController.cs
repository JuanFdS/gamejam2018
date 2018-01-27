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
		if(this.transform.position.x != previousPosition.x)
        {
            previousPosition = this.transform.position;
            AnimationController.SetFloat("Speed", 1);
        }
        else
            AnimationController.SetFloat("Speed", 0);
    }
    
}
