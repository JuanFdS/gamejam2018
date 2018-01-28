using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AntennaSound : MonoBehaviour {

	public Transform earTransform;
	public AudioSource audioSource;
	public AudioSource backgroundAudio;
	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource>();
		GetComponent<CircleCollider2D>().radius = audioSource.maxDistance;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Bird")) {
			backgroundAudio.mute = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Bird")) {
			backgroundAudio.mute = false;
		}
	}
}
