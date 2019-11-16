using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    //Attacks per second
    [SerializeField] private float attacksPerSec;
    //Projectile prefab
    [SerializeField] private GameObject projectile;
    //The targetfinder
    private TargetFinder targetfinder;
    //Used to shoot
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        targetfinder = GetComponent<TargetFinder>();
        counter = 4;
    }
    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 1 / attacksPerSec)
        {
            if (targetfinder.targets != null)
            {
                shoot(targetfinder.targets[0]);
                counter = 0;
            }
        }
        /*else
        {
            Debug.Log("No target");
        }*/
    }

    void shoot(GameObject target)
    {
        //Debug.Log("Shooting a " + projectile + " at: " + target);
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        proj.GetComponent<Projectile>().shootAt(target);
    }
}
