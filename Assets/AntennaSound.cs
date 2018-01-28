using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaSound : MonoBehaviour {

	public Transform earTransform;
	AudioSource audioSource;
	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var distance = Vector2.Distance(earTransform.position, transform.position);
		audioSource.volume = 1 / distance;
		Debug.log(distance);
		Debug.Log(audioSource.volume);
	}
}
