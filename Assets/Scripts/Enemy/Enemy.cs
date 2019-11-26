using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

[RequireComponent( typeof(WalkAlongPath), typeof(DamageSystem), typeof(AttributeManager))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] private float speed = 1f;

    private WalkAlongPath walkScript;
    private PathCreator path;
    private DamageSystem damageSystem;

    void DestroyItself() {
        Destroy(gameObject.transform.parent.transform.parent.gameObject);
    }

    void Start()
    {
        // Has to be changed to a dynamic path selection after spawn in the future as a map could contain several paths
        path = GameObject.Find("Path").GetComponent<PathCreator>();

        walkScript = GetComponent<WalkAlongPath>();
        walkScript.pathCreator = path;
        walkScript.speed = speed;
        damageSystem = GetComponent<DamageSystem>();
        damageSystem.onDeath.AddListener(DestroyItself);
    }
}
