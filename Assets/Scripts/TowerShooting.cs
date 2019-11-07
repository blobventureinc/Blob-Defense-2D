using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
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
        if (targetfinder.targets != null && counter > 1)
        {
            foreach (GameObject target in targetfinder.targets)
            {
                shoot(target);
            }
            counter = 0;
        }
        else
        {
            Debug.Log("No target");
            counter += Time.deltaTime;

        }
    }

    void shoot(GameObject target)
    {
        Debug.Log("Shooting a " + projectile + " at: " + target);
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        //proj.AddComponent(projectileBehaviour.GetType());
        proj.GetComponent<Projectile>().shootAt(target);

    }
}
