using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkDirection : MonoBehaviour
{
    public Vector3 dir;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position+= dir * speed * Time.deltaTime;
    }
}
