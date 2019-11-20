using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lives : MonoBehaviour
{
    [Header("Starting Life as Int Total")]
    [SerializeField] private int _startLives = 10;
    [SerializeField] private int _startMaxLives = 10;

    public Attribute lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = new Attribute(_startLives, _startMaxLives);
    }
}
