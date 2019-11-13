using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    //Projectilespeed
    public float speed;
    //Target of the projectile
    protected GameObject target_;
    //Setter for the target, always use this wehen instantiating a new Projectile
    public abstract void shootAt(GameObject target);
    //Impact behaviour, damage etc
    protected abstract void impact();

    //Projectile collision behaviour, can be used for area damage
}
