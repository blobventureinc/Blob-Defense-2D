using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closest : TargetFinder
{
    public override List<GameObject> targets
    {
        get => _targets;
    }
    public override void Start()
    {
        _targets = new List<GameObject>();
    }
    public override void Update()
    {
        targets.Sort((emp1, emp2) => Vector3.Distance(gameObject.transform.position, emp1.transform.position).CompareTo(Vector3.Distance(gameObject.transform.position, emp2.transform.position)));
    }

    //Collision
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        _targets.Add(other.gameObject);
    }
    protected override void OnTriggerStay2D(Collider2D other) { }
    protected override void OnTriggerExit2D(Collider2D other) { }
}
