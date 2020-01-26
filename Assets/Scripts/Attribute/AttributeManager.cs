using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    [Header("Should the Attributes (Health) scale up by level?")]
    public bool isScalabeByLevel = true;

    [Header("Init Values")]
    public int _baseHealth = 100;
    public int _baseMana = 10;
    public int _baseEnergy = 100;
    public int _initGold = 0;

    [Header("Experience")]
    [SerializeField] private int _exp = 0;
    [SerializeField] private int _expMax = 1000;

    [Header("Level")]
    [SerializeField] private int _level = 0;
    [SerializeField] private int _levelMax = 20;

    public Attribute health;
    public Attribute mana;
    public Attribute energy;
    public Attribute exp;
    public Attribute level;
    public Attribute skillPoints;
    public Attribute gold;

    // Start is called before the first frame update
    void Start()
    {
        health = new Attribute(_baseHealth, _baseHealth);
        mana = new Attribute(_baseMana, _baseMana);
        energy = new Attribute(_baseEnergy, _baseEnergy);
        exp = new Attribute(_exp, _expMax);
        level = new Attribute(_level, _levelMax);
        skillPoints = new Attribute(0);
        gold = new Attribute(_initGold);

        exp.onValueChange.AddListener(LevelUp);

        if (isScalabeByLevel) {
            level.onValueChange.AddListener(ScaleHealthLevel);
            ScaleHealthLevel();
        }

        // Init UI Scripts
        if (GameObject.Find("UI") != null) {
            GameObject.Find("UI").GetComponent<UpdatePlayerAttributes>().Init();
        }
        if (GetComponent<HealthBar>() != null) {
            GetComponent<HealthBar>().Init();
        }
    }

    public void ScaleHealthLevel() {
        health.SetMax(_baseHealth + level.value * 10);
    }

    public void LevelUp() {
        if (exp.value >= exp.valueMax) {
            level.Increase(1);
            skillPoints.Increase(1);
            exp.Set(0);
        }
    }
}
