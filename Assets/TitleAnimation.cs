using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour {

    float endY;

	// Use this for initialization
	void Start () {
        endY = transform.position.y;
        transform.position = new Vector2(transform.position.x, transform.position.y + 150);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > endY)
            transform.position = new Vector2(transform.position.x, transform.position.y - 2);
        else
            transform.position = new Vector2(transform.position.x, endY);
    }
}
