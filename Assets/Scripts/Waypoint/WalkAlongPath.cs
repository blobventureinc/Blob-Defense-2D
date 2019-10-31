using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class WalkAlongPath : MonoBehaviour {
    public PathCreator pathCreator;
    public float speed;

    private float position;

    void FixedUpdate() {
        position += Time.deltaTime * speed;
        transform.position = pathCreator.path.GetPointAtDistance(position, EndOfPathInstruction.Stop);
    }
}
