using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkyColor : MonoBehaviour {

	private Camera camera;
	private Color originalBackgroundColor;
	private Transform sun;
	private Color originalSunColor;
	// Use this for initialization
	void Awake () {
		camera = GetComponent<Camera>();
		originalBackgroundColor = camera.backgroundColor;
		sun = transform.GetChild(0);
		originalSunColor = sun.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var percentageOfDay = sun.GetComponent<SunMovement>().TrajectPercentage();
		var isNight = percentageOfDay >= 0.5f;
		if(isNight) {
			sun.GetComponent<SpriteRenderer>().color = originalSunColor * 1.25f;
			camera.backgroundColor = Color.black;
		} else {
			sun.GetComponent<SpriteRenderer>().color = originalSunColor;
			var foo = percentageOfDay * 2;
			var blackMagic = -5.1f * Mathf.Pow(foo - 0.5f, 2) + 0 * (foo-0.5f) + 1.2f;
			var atardecer = (-18.3f * Mathf.Pow(foo + 0.3f, 2) + 26f * (foo + 0.3f) - 8.1f) / 3;
			var rojo = Color.red * Math.Max(0, atardecer);
			camera.backgroundColor = originalBackgroundColor * blackMagic + rojo;
		}
	}
}
