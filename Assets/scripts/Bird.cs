using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : PlayerControlled {

    Rigidbody2D rb;
    Camera mainCamera;
    EnergyBarFiller energyBar;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
        energyBar = GameManager.singletone.Relleno.GetComponent<EnergyBarFiller>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (Input.GetKey(KeyCode.T) && energyBar.energy > 0)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 0.3f);
            energyBar.energy -= 0.5f;
        }
        if (Input.GetKey(KeyCode.Y))
        {
            energyBar.energy = 100;
        }
        rb.velocity = new Vector2(2, rb.velocity.y);
        transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y);
        mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, -10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Collider2D>().CompareTag("Floor"))
        {
            die();
            //Debug.Log();
        };
    }

    public void aumentarEnergia()
    {
        energyBar.energy += 1f;
        if (energyBar.energy > 100) energyBar.energy = 100;
    }

    public void push()
    {
        rb.velocity = new Vector2(rb.velocity.x, 8);
    }
}
 