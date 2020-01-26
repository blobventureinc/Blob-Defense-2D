using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [Header("Projectile attributes")]
    [SerializeField] protected float speed;
    [SerializeField] protected Damage dmg;
    protected GameObject _target;
    protected Vector3 lastTarget;

    //Message methods
    public abstract void Start();
    public abstract void Update();
    //Setter for the target, always use this wehen instantiating a new Projectile
    public void shootAt(GameObject target)
    {
        _target = target;
    }
    protected abstract void OnTriggerEnter2D(Collider2D other);
    //Impact behaviour, damage etc
    protected abstract void impact(GameObject enemy);

    protected void damage(GameObject enemy, Damage damage)
    {
        if (enemy.tag != "Player")
            enemy.GetComponent<HealthSystem>().ApplyDamage(damage);
    }
    protected void DestroyItself()
    {
        Destroy(gameObject);
    }
}
