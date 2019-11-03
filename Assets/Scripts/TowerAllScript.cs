using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAllScript : MonoBehaviour
{
    public class Attributes
    {
        public List<GameObject> targets;
        public Attributes()
        {
            targets = new List<GameObject>();
        }
    }
    Attributes att;
    boolean attacking;

    // Start is called before the first frame update
    void Start()
    {
        att = new Attributes();
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(att.targets.Count);
        att.targets.Add(other.gameObject);
        if (!attacking)
        {
            attacking = true;

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(att.targets.Count);
        Debug.Log("Stays");

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited");
        att.targets.Remove(other.gameObject);
        if (att.targets.Count == 0)
        {
            attacking = false;
        }

    }
}
