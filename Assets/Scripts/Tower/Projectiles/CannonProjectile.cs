using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : Projectile
{
    public override void Start()
    {
        //_target.GetComponent<HealthSystem>().onDeath.AddListener(DestroyItself);
        lastTarget = _target.transform.position;
    }
    public override void Update()
    {
        //Go to target
        float step = speed * Time.deltaTime;
        if (_target != null)
            lastTarget = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
        else
            if (gameObject.transform.position == lastTarget) DestroyItself();
        transform.position = Vector3.MoveTowards(transform.position, lastTarget, step);
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _target)
            impact(other.gameObject);
    }
    protected override void impact(GameObject enemy)
    {
        damage(enemy, dmg);
        DestroyItself();
    }
}
