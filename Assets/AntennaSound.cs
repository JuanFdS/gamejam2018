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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var distance = Vector2.Distance(earTransform.position, transform.position);
		backgroundAudio.mute = audioSource.maxDistance >= distance;
	}
}
