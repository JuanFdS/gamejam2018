using UnityEngine;
using UnityStandardAssets._2D;

public class SlowDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other) {
        if(other.GetComponent<Collider2D>().CompareTag("Player")) {
            other.GetComponent<PlatformerCharacter2D>().SlowDown();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.GetComponent<Collider2D>().CompareTag("Player")) {
            other.GetComponent<PlatformerCharacter2D>().BackToRegularSpeed();
        }
    }
}
