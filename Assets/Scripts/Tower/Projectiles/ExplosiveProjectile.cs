using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [Header("Explosive Projectile attributes")]
    [SerializeField] private float max_radius = 0;
    [SerializeField] private Damage explosion_damage;

    private bool exploded;
    private CircleCollider2D explosionCollider;

    public override void Start()
    {
        exploded = false;
        explosionCollider = GetComponent<CircleCollider2D>();
    }
    public override void Update()
    {
        if (!exploded)
        {
            //Go to target
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target_.transform.position, step);
        }
        else
        {
            //Increment the radius of the wave and destroy the projectile if the max_radius is reached
            float step = speed * Time.deltaTime;
            explosionCollider.radius += step;
            if (explosionCollider.radius >= max_radius)
            {
                Destroy(gameObject);
            }
        }
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        impact(other.gameObject);
        if (!exploded)
        {
            explode();
        }
    }

    protected override void impact(GameObject enemy)
    {
        if(!exploded)
            Debug.Log("Hit with impact " + enemy);
        else
            Debug.Log("Hit with explosion" + enemy);

    }

    private void explode()
    {
        exploded = true;
    }
}
