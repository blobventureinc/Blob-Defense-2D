using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetFinder : MonoBehaviour
{
    //Targets
    protected List<GameObject> _targets;
    public abstract List<GameObject> targets
    {
        get;
    }
    // Start is called before the first frame update
    public abstract void Start();
    public abstract void Update();
    //Collision
    protected abstract void OnTriggerEnter2D(Collider2D other);
    protected abstract void OnTriggerStay2D(Collider2D other);
    protected abstract void OnTriggerExit2D(Collider2D other);
}