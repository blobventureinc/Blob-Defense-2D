using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : Projectile
{
    private float speed_;

    // Start is called before the first frame update
    void Start()
    {
        speed_ = 1f;
    }

    // Update is called once per frame
    public override void Update()
    {
        //Go to target
        float step = speed_ * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target_.transform.position, step);
    }

    public override void shootAt(GameObject target)
    {
        target_ = target;
    }

    //Projectile collision behaviour, can be used for area damage
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
    protected override void OnTriggerStay2D(Collider2D other)
    {

    }
    protected override void OnTriggerExit2D(Collider2D other)
    {

    }
}
