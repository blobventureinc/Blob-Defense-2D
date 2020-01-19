using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherOnDestroy : MonoBehaviour
{
    public GameObject obj;
    
    void OnDestroy() 
    {
        Destroy(obj);
    }
}
