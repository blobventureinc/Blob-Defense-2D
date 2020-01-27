using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] private Light2D lightSource = null;
    public float flickerTimer;
    public float flickerRadius;
    private float timer;
    private float initialIntensity;
    // Start is called before the first frame update
    void Start()
    {
        initialIntensity = lightSource.intensity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= flickerTimer) {
            lightSource.pointLightOuterRadius = Random.Range(flickerRadius, flickerRadius + Random.Range(0.0f, 0.4f));
            timer = 0;
            lightSource.intensity = Random.Range(initialIntensity, initialIntensity+0.1f);
        }
    }
}
