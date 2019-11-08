using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    //Target of the projectile
    protected GameObject target_;
    // Start is called before the first frame update
    void Start() { }
    // Update is called once per frame
    public abstract void Update();
    //Setter for the target, always use this wehen instantiating a new Projectile
    public abstract void shootAt(GameObject target);
    //Projectile collision behaviour, can be used for area damage
    protected abstract void OnTriggerEnter2D(Collider2D other);
    protected abstract void OnTriggerStay2D(Collider2D other);
    protected abstract void OnTriggerExit2D(Collider2D other);
}
