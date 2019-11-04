using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    private List<GameObject> _targets;
    public GameObject target
    {
        get
        {
            if (_targets.Count != 0)
                return _targets[0];
            else
                return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _targets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        _targets.Add(other.gameObject);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Target out of range, its " + other.gameObject);
        _targets.Remove(other.gameObject);

    }

}
