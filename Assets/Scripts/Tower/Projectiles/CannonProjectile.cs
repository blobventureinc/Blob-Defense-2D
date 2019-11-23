using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : Projectile
{
    public override void Start()
    {
        _target.GetComponent<HealthSystem>().onDeath.AddListener(DestroyItself);
    }
    public override void Update()
    {
        //Go to target
        float step = speed * Time.deltaTime;
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _target)
            impact(other.gameObject);
    }
    protected override void impact(GameObject enemy)
    {
        damage(enemy, dmg);
        Destroy(gameObject);
    }
}
