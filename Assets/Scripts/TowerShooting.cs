using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    private Projectile projectile;
    private TargetFinder targetfinder;


    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Projectile>();
        targetfinder = GetComponent<TargetFinder>();

    }
    
    // Update is called once per frame
    void Update()
    {
        if (targetfinder.target!=null)
        {
            shoot();
        }
        else
        {
            Debug.Log("No target");

        }
    }

    void shoot()
    {
        Debug.Log("Shooting a "+projectile+" at: " +targetfinder.target);
    }
}
