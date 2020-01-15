using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetFinder))]
public class TowerShooting : MonoBehaviour
{
    public float attacks_per_sec = 0;
    //Projectile prefab
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private TargetFinder targetfinder = null;
    private float time_since_last_shot_ = 100;

    // Start is called before the first frame update
    void Start() { }
    // Update is called once per frame
    void Update()
    {
        time_since_last_shot_ += Time.deltaTime;
        if (time_since_last_shot_ > 1 / attacks_per_sec)
        {
            if (targetfinder.targets.Count != 0)
            {
                if (targetfinder.targets[0].tag == "Enemy")
                {
                    shoot(targetfinder.targets[0]);
                    resetShootTime();
                }
            }
        }
    }

    void shoot(GameObject target)
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        proj.transform.parent = gameObject.transform;
        proj.GetComponent<Projectile>().shootAt(target);
    }

    public void resetShootTime()
    {
        time_since_last_shot_ = 0;
    }
}
