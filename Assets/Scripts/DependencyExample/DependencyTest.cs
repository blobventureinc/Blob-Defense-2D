using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DependencyTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Projectile x = GetComponent<Projectile>();
        x.myNameIs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
