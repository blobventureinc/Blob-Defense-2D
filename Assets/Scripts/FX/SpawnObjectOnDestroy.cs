using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDestroy : MonoBehaviour
{
    public GameObject obj;

    void OnDestroy() 
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }
}
