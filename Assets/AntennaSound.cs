using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AntennaSound : MonoBehaviour {

	public Transform earTransform;
	public AudioSource audioSource;
	public AudioSource backgroundAudio;
	// Use this for initialization
	public bool reducingBackVolume;
	public bool increasingBackVolume;

	void Awake () {
		backgroundAudio = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
		audioSource = GetComponent<AudioSource>();
		GetComponent<CircleCollider2D>().radius = audioSource.maxDistance / 2;
	}

	public void FixedUpdate () {
		if(reducingBackVolume) {
			backgroundAudio.volume -= 0.025f;
			if(backgroundAudio.volume <= 0) reducingBackVolume = false;
		}
		if (increasingBackVolume) {
			backgroundAudio.volume += 0.025f;
			if(backgroundAudio.volume >= 1) increasingBackVolume = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Bird")) {
			reducingBackVolume = true;
			increasingBackVolume = false;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Bird")) {
			increasingBackVolume = true;
			reducingBackVolume = false;
		}
	}
}
