using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectile : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {

    }
    public override void shootAt( GameObject target)
    {
        Debug.Log("I am a Pistol Projectile!");
    }

    public override bool alive()
    {
        return true;
    }
}
