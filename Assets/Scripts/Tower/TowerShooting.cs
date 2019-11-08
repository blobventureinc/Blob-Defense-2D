using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public float attacksPerSec;
    public GameObject projectile;
    private Projectile projectileBehaviour;
    private TargetFinder targetfinder;
    private float counter;


    // Start is called before the first frame update
    void Start()
    {
        projectileBehaviour = GetComponent<Projectile>();
        targetfinder = GetComponent<TargetFinder>();
        counter = 4;

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (targetfinder.targets != null)
        {
            if (counter > 1/attacksPerSec)
            {
                shoot(targetfinder.targets[0]);
                counter = 0;
            }
        }
        else
        {
            Debug.Log("No target");
        }
    }

    void shoot(GameObject target)
    {
        Debug.Log("Shooting a " + projectile + " at: " + target);
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        proj.GetComponent<Projectile>().shootAt(target);

    }
}
