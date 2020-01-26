using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class WaveProjectile : Projectile
{
    [Header("Wave Projectile attributes")]
    [SerializeField] private float max_radius = 0;
    [SerializeField] private CircleCollider2D waveCollider = null;

    public override void Start() { }
    public override void Update()
    {
        //Increment the radius of the wave and destroy the projectile if the max_radius is reached
        float step = speed * Time.deltaTime;
        waveCollider.radius += step;
        if (waveCollider.radius >= max_radius)
        {
            DestroyItself();
        }
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        impact(other.gameObject);
    }
    protected override void impact(GameObject enemy)
    {
        damage(enemy, dmg);
    }
}
