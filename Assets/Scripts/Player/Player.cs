using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Reflection;
using Microsoft.VisualBasic;

public class Player : MonoBehaviour
{
    [Header("Init Life as Int Total")]
    [SerializeField] private int _lives = 10;
    [SerializeField] private int _maxLives = 10;

    [Header("Init Mana as Int Total")]
    [SerializeField] private int _mana = 10;
    [SerializeField] private int _maxMana = 10;

    [Header("Init Energy as Int Percent")]
    [SerializeField] private int _energy = 100;

    [Header("Init Exp as Int Total")]
    [SerializeField] private int _exp = 0;
    [SerializeField] private int _maxExp = 1000;

    [Header("Init Level")]
    [SerializeField] private int _level = 0;
    [SerializeField] private int _maxLevel = 20;

    [Header("Init Gold as Int Total")]
    [SerializeField] private int _gold = 0;

    public Attribute lives;
    public Attribute mana;
    public Attribute energy;
    public Attribute exp;
    public Attribute level;
    public Attribute gold;

    public void Start() {
        lives = new Attribute(_lives, _maxLives);
        mana = new Attribute(_mana, _maxMana);
        energy = new Attribute(_energy, 100);
        exp = new Attribute(_exp, _maxExp);
        level = new Attribute(_level, _maxLevel);
        gold = new Attribute(_gold);
        GameObject.Find("UI").GetComponent<UpdatePlayerAttributes>().Init();
    }
}
