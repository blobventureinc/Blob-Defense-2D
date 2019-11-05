using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : Projectile
{
    public GameObject target_;
    private float speed_;
    private Vector3 startPos;
    private float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        speed_ = 1f;
        lifetime = 0f;
        startPos = new Vector3(transform.position[0], transform.position[1], transform.position[2]);
    }

    // Update is called once per frame
    public override void Update()
    {
        Debug.Log("I am updating" + gameObject);
        Debug.Log(target_ == null);

        if (target_ != null)
        {
            float step = speed_ * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target_.transform.position, step);
            if (Vector3.Distance(transform.position, target_.transform.position) < 0.001 || !alive())
            {
                Destroy(gameObject);
            }
        }
        lifetime += Time.deltaTime;
    }

    public override void shootAt(GameObject target)
    {
        target_ = target;
    }

    public override bool alive()
    {
        if (Vector3.Distance(startPos, transform.position) < 1 && lifetime < 10)
            return true;
        else
            return false;

    }
    //To initialize a Projectile with its parameters
    public CannonProjectile create(GameObject where, float speed /*complete parameterlist*/)
    {
        CannonProjectile cp = where.AddComponent<CannonProjectile>();
        cp.speed_ = speed; //for every parameter
        return cp;

    }
}
