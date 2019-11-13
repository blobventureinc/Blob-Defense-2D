using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDependant : TargetFinder
{
    public override List<GameObject> targets
    {
        get => _targets;
    }
    public override void Start()
    {
        _targets = new List<GameObject>();
    }
    public override void Update() { }
    //Collision
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        _targets.Add(other.gameObject);
    }
    protected override void OnTriggerStay2D(Collider2D other) { }
    protected override void OnTriggerExit2D(Collider2D other)
    {
        _targets.Remove(other.gameObject);
        Debug.Log("Ich bin nicht");

    }
}

