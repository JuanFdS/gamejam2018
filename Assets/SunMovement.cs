using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SunMovement : MonoBehaviour {

	// Use this for initialization
	public float trajectOffset;
	public Vector2 radius;
	public Vector2 center;
	public float speed;
	public float indiceMagicoDeCircunferenciaPermitida;

	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var t = (Time.time * speed) % indiceMagicoDeCircunferenciaPermitida;
		float newX = (radius.x * Mathf.Sin(t + trajectOffset) + center.x);
		float newY = (radius.y * Mathf.Cos(t + trajectOffset) + center.y);
		transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
	}

	public float TrajectPercentage () {
		return ((Time.time * speed) % (indiceMagicoDeCircunferenciaPermitida * 2)) / (indiceMagicoDeCircunferenciaPermitida * 2)	;
	}
}
