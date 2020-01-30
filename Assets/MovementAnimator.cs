using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimator : MonoBehaviour {

    [SerializeField] Animator anim = null;

    Vector3 oldPosition;
    Vector3 newPosition;
    Vector3 direction;
    bool step;

    private void Start() {
        anim = GetComponent<Animator>();
    }


    private void Update() {
        if (step) {
            oldPosition = transform.position;
            step = false;
        } else {
            newPosition = transform.position;
            var heading = newPosition - oldPosition;
            var distance = heading.magnitude;
            Vector3 direction = heading / distance;
            if (!float.IsNaN(direction.x)) {
                anim.SetFloat("SpeedX", direction.x);
                anim.SetFloat("SpeedY", direction.y);
            }
            step = true;
        }
    }
}
