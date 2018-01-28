using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnJugarAnimation : MonoBehaviour {

    int cont;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        cont++;
        if (cont > 80)
        {
            if (transform.localScale.x < 1f)
                transform.localScale = new Vector2(transform.localScale.x + 0.03f, transform.localScale.y + 0.03f);
            else
                transform.localScale = new Vector2(1, 1);
        }
    }
}
