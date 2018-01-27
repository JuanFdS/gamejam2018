using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antena : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Bird"))
        {
            collision.GetComponent<Bird>().aumentarEnergia();
            //Debug.Log();
        }
    }
}
