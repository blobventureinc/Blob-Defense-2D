﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class flickerLight : MonoBehaviour
{
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D light;
    public float flickerTimer;
    public float flickerRadius;
    private float timer;
    private float initialIntensity;
    // Start is called before the first frame update
    void Start()
    {
        initialIntensity = light.intensity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= flickerTimer) {
            light.pointLightOuterRadius = Random.Range(flickerRadius, flickerRadius + Random.Range(0.0f, 0.4f));
            timer = 0;
            light.intensity = Random.Range(initialIntensity, initialIntensity+0.1f);
        }
    }
}
