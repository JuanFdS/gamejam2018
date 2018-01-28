using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrainPosToScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, transform.position.y);
        }
        else if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x, transform.position.y);
        }
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)));
	}
}
