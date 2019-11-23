using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [Header("Explosive Projectile attributes")]
    [SerializeField] private float max_radius = 0;
    [SerializeField] private Damage explosion_damage = null;

    private bool exploded;
    private CircleCollider2D explosionCollider;

    public override void Start()
    {
        exploded = false;
        explosionCollider = GetComponent<CircleCollider2D>();
        _target.GetComponent<HealthSystem>().onDeath.AddListener(DestroyItself);
    }
    public override void Update()
    {
        if (!exploded)
        {
            //Go to target
            float step = speed * Time.deltaTime;
            if (_target != null)
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
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
        if (_target == null)
            Destroy(gameObject);
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
        if (!exploded)
            damage(enemy, explosion_damage);
        else
            damage(enemy, dmg);
    }

    private void explode()
    {
        exploded = true;
    }
}
