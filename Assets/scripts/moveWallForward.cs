using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWallForward : MonoBehaviour {

	public Transform transformCamara;
	public float offsetCamara;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector2(transformCamara.position.x + offsetCamara, transform.position.y);
	}
}
