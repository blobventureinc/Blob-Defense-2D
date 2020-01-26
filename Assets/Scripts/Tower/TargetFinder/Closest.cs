using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closest : TargetFinder
{
    public override void Update()
    {
        targets.Sort((emp1, emp2) => Vector3.Distance(gameObject.transform.position, emp1.transform.position).CompareTo(Vector3.Distance(gameObject.transform.position, emp2.transform.position)));
    }
}
