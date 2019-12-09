using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

[RequireComponent( typeof(WalkAlongPath), typeof(HealthSystem), typeof(AttributeManager))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private new string name;

    private WalkAlongPath walkScript;
    private PathCreator path;
    private HealthSystem healthSystem;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Castle") {

        }
    }
}
