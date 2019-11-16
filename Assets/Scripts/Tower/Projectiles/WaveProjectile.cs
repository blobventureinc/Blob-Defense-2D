using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectile : Projectile
{
    public float max_radius;
    private CircleCollider2D waveCollider;

    public override void Start()
    {
        waveCollider = GetComponent<CircleCollider2D>();
    }
    public override void Update()
    { 
        //Increment the radius of the wave and destroy the projectile if the max_radius is reached
        float step = speed * Time.deltaTime;
        waveCollider.radius += step;
        if (waveCollider.radius >= max_radius)
        {
            Destroy(gameObject);
        }
    }

    protected override void impact(GameObject enemy)
    {
        Debug.Log("Hit "+ enemy);
    }
}
