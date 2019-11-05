using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

[RequireComponent( typeof(WalkAlongPath), typeof(HealthSystem) )]
public class Enemy : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] private float speed;

    private WalkAlongPath walkScript;
    private PathCreator path;
    private HealthSystem healthSystem;

    void DestroyItself() {
        Destroy(gameObject.transform.parent.transform.parent.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        path = GameObject.Find("Path").GetComponent<PathCreator>();
        walkScript = GetComponent<WalkAlongPath>();
        walkScript.pathCreator = path;
        walkScript.speed = speed;
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.onDeath.AddListener(DestroyItself);
    }
}
