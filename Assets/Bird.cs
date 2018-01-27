using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
        }
        transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y);
    }
}
 