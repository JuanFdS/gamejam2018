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
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.GetComponent<Collider2D>().CompareTag("Player")) {
            collision.collider.GetComponent<PlayerControlled>().die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().CompareTag("Bird"))
        {
            rb.gravityScale = 3;
        }
    }
}
