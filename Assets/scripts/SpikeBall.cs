using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour {


    public AudioSource fall;
    private Rigidbody2D rb;
    private bool isFloored;
	// Use this for initialization
	void Start () {
        rb =  GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
        isFloored = false;
	}
	
	// Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.GetComponent<Collider2D>().CompareTag("Player")) {
            collision.collider.GetComponent<PlayerControlled>().die();
        } else if (!collision.collider.GetComponent<Collider2D>().CompareTag("Floor") && !isFloored) {
            fall.Play();
        } else if (collision.collider.GetComponent<Collider2D>().CompareTag("Floor")) {
            isFloored = true;
        }
        rb.gravityScale = 3;
    }
}
