using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ExplosiveProjectile : Projectile
{
    [Header("Explosive Projectile attributes")]
    [SerializeField] private float max_radius = 0;
    [SerializeField] private Damage explosion_damage = null;
    private bool exploded = false;
    [SerializeField] private CircleCollider2D explosionCollider = null;

    public override void Start()
    {
        //_target.GetComponent<HealthSystem>().onDeath.AddListener(DestroyItself);
        lastTarget = _target.transform.position;
    }

    public override void Update()
    {
        if (!exploded)
        {
            //Go to target
            float step = speed * Time.deltaTime;
            if (_target != null)
                lastTarget = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
            else
                if (gameObject.transform.position == lastTarget) explode();
            transform.position = Vector3.MoveTowards(transform.position, lastTarget, step);
        }
        else
        {
            //Increment the radius of the wave and destroy the projectile if the max_radius is reached
            float step = speed * Time.deltaTime;
            explosionCollider.radius += step;
            if (explosionCollider.radius >= max_radius)
            {
                DestroyItself();
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
        if (exploded)
            damage(enemy, explosion_damage);
        else
            damage(enemy, dmg);
    }

    private void explode()
    {
        exploded = true;
    }
}
