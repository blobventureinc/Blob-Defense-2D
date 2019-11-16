using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : Projectile
{
    public override void  Start() { }
    public override void Update()
    {
        //Go to target
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target_.transform.position, step);
    }
    protected override void impact(GameObject enemy)
    {
        Destroy(gameObject);
    }
}
