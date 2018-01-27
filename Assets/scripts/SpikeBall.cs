using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour {

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb =  GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Bird"))
        {
            rb.gravityScale = 3;
            //Debug.Log();
        }
    }
}
