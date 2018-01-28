using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControlled : MonoBehaviour {

	Rigidbody2D rb;
	private float timeLeftToTrip;
	private UnityStandardAssets._2D.Platformer2DUserControl control;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		timeLeftToTrip = 0;
		control = GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		control.enabled = !IsTripping();
		timeLeftToTrip = Math.Max(0, timeLeftToTrip - 1);
	}

	private bool IsTripping () {
		return timeLeftToTrip > 0;
	}

	public void die()
    {
        //enabled = false;
        gameObject.SetActive(false);
    }

	public void trip(float slowDownFactor, float timeToTrip){
		rb.velocity = GetComponent<Rigidbody2D>().velocity * slowDownFactor;
		timeLeftToTrip = timeToTrip;
	}
}
