using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDependant : TargetFinder
{
    public override List<GameObject> targets
    {
        get
        {
            if (_targets.Count != 0)
                return _targets;
            else
                return null;
        }
    }
    public override void Start()
    {
        _targets = new List<GameObject>();
    }
    //Collision
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        _targets.Add(other.gameObject);
    }
    protected override void OnTriggerStay2D(Collider2D other)
    {
    }
    protected override void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Target out of range, its " + other.gameObject);
        _targets.Remove(other.gameObject);

    }
}

