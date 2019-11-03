using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnCollide : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Stays");

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");

    }
}
