using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectile : Projectile
{
    // Start is called before the first frame update
    void Start() { }
    // Update is called once per frame
    public void Update()
    {
        //Go to target
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target_.transform.position, step);
    }
    //Projectile collision behaviour, can be used for area damage
    protected void OnTriggerEnter2D(Collider2D other)
    {
        impact();
        Destroy(gameObject);
    }
    //protected void OnTriggerStay2D(Collider2D other) { }
    //protected void OnTriggerExit2D(Collider2D other) { }

    //A setter used in the TowerShoot-Behaviour
    public override void shootAt(GameObject target)
    {
        target_ = target;
    }
    protected override void impact()
    {
    }
}
