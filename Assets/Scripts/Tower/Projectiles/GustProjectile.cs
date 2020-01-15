using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustProjectile : Projectile
{
    [Header("Gust Projectile attributes")]
    private float life_time = 0;
    [SerializeField] private float attacks_per_sec = 0;
    [SerializeField] private float range_radius = 0;
    private Vector3 start_position;
    private TowerShooting tower_shooting = null;
    private TargetFinder targetfinder = null;
    private float time_since_last_shot_ = 1000;

    public override void Start()
    {
        Transform t = gameObject.transform;
        start_position = new Vector3(t.position.x, t.position.y, t.position.z);
        targetfinder = t.parent.GetComponent<TargetFinder>() as TargetFinder;
        tower_shooting = t.parent.GetComponent<TowerShooting>() as TowerShooting;

        life_time = 10 / tower_shooting.attacks_per_sec;
    }
    public override void Update()
    {
        float step = speed * Time.deltaTime;
        if (life_time - range_radius / speed > 0)
        {
            //Go to target
            if (targetfinder.targets.Count == 0)
                _target = null;
            else
                _target = targetfinder.targets[0];
            //Go to target or start_position
            if (_target != null)
            {
                if (_target.tag = "enemy")
                {
                    transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
                    //Damage
                    if (Vector3.Distance(transform.position, _target.transform.position) <= 0.03)
                    {
                        impact(_target);
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, start_position, step);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, start_position, step);
            if (life_time <= 0)
                DestroyItself();
        }
        time_since_last_shot_ += step;
        life_time -= step;
    }
    protected override void OnTriggerEnter2D(Collider2D other) { }
    protected override void impact(GameObject enemy)
    {
        if (time_since_last_shot_ > 1 / attacks_per_sec)
        {
            damage(enemy, dmg);
            time_since_last_shot_ = 0;
        }
    }
}
