﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Transform birdTransform;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(birdTransform.position.x, transform.position.y, -10);
    }
}
