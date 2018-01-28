using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trip : MonoBehaviour {

	public float slowDownFactor;
	public float trippingTime;
	public System.String tagTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.GetComponent<Collider2D>().CompareTag(tagTarget))
        {
            collision.GetComponent<PlayerControlled>().trip(slowDownFactor, trippingTime);
        }
	}
}
