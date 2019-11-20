using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    //Projectilespeed
    [SerializeField]protected float speed;
    //Damage
    [SerializeField] protected Damage dmg;
    //Target of the projectile
    protected GameObject target_;
    //Message methods
    public abstract void Start();
    public abstract void Update();

    //Setter for the target, always use this wehen instantiating a new Projectile
    public void shootAt(GameObject target)
    {
        target_ = target;
    }
    protected abstract void OnTriggerEnter2D(Collider2D other);
    //Impact behaviour, damage etc
    protected abstract void impact(GameObject enemy);
}
