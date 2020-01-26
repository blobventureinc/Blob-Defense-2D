using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetFinder : MonoBehaviour
{
    //Targets
    protected List<GameObject> _targets;
    public List<GameObject> targets
    {
        get
        {
            _targets.RemoveAll((GameObject item) =>
            {
                if (item == null)
                {
                    return true;
                }
                else
                {
                    if (item.tag != "Enemy")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            });
            return _targets;
        }
    }
    //Maybe will change to virtual
    public void Start()
    {
        _targets = new List<GameObject>();
    }
    //Do not make this one virtual, it would look good, but there should never be an instance of the class: TargetFinder
    //only specific subclasses like Closest and TimeDependant. Right now we specify through the name exactly what the class does!
    public abstract void Update();

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _targets.Add(other.gameObject);
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        _targets.Remove(other.gameObject);
    }
}