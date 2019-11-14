using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class DebugSpawnerTrigger : MonoBehaviour
{
    private Spawner spawner;

    void Start() 
    {
        spawner = GetComponent<Spawner>();
    }

    void Update() 
    {
        if(Input.GetButtonDown("Jump")) 
        {
            spawner.SpawnNextWave();
        }
    }
}
