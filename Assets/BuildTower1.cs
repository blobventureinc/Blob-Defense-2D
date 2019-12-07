using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildTower1 : MonoBehaviour
{
    private UnityEvent buildTower;

    void Invoke()
    {
        buildTower.Invoke();
    }

    //void saymyname()
    //{
    //    Debug.Log("sss");
    //}
}
