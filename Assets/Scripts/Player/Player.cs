using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Starting Life as Int Total")]
    [SerializeField] private int _lives = 10;
    [SerializeField] private int _maxLives = 10;

    [Header("Starting Mana as Int Total")]
    [SerializeField] private int _mana = 10;
    [SerializeField] private int _maxMana = 10;

    [Header("Starting Energy as Int Percent")]
    [SerializeField] private int _energy = 100;

    [Header("Starting Exp as Int Total")]
    [SerializeField] private int _exp = 0;
    [SerializeField] private int _maxExp = 1000;

    [Header("Starting Level")]
    [SerializeField] private int _level = 0;
    [SerializeField] private int _maxLevel = 20;

    [Header("Starting Gold as Int Total")]
    [SerializeField] private int _gold = 0;

    public Attribute lives;
    public Attribute mana;
    public Attribute energy;
    public Attribute exp;
    public Attribute level;
    public Attribute gold;

    public UnityEvent onLivesChange;
    public UnityEvent onManaChange;
    public UnityEvent onEnergyChange;
    public UnityEvent onExpChange;
    public UnityEvent onLevelChange;
    public UnityEvent onGoldChange;
    public UnityEvent onStart;

    public void Start() {
        lives = new Attribute(_lives, _maxLives);
        mana = new Attribute(_mana, _maxMana);
        energy = new Attribute(_energy, 100);
        exp = new Attribute(_exp, _maxExp);
        level = new Attribute(_level, _maxLevel);
        gold = new Attribute(_gold);
        onStart.Invoke();
    }

    // // // // // // // // // // // //
    // LIVES
    public void IncreaseLives(int value) {
        lives.Increase(value);
        onLivesChange.Invoke();
    }
    public void DecreaseLives(int value) {
        lives.Decrease(value);
        onLivesChange.Invoke();
    }
    public void IncreaseLivesMax(int value) {
        lives.IncreaseMax(value);
        onLivesChange.Invoke();
    }
    public void DecreaseLivesMax(int value) {
        lives.DecreaseMax(value);
        onLivesChange.Invoke();
    }
    // // // // // // // // // // // //
    // MANA
    public void IncreaseMana(int value) {
        mana.Increase(value);
        onManaChange.Invoke();
    }
    public void DecreaseMana(int value) {
        mana.Decrease(value);
        onManaChange.Invoke();
    }
    public void IncreaseManaMax(int value) {
        mana.IncreaseMax(value);
        onLivesChange.Invoke();
    }
    public void DecreaseManaMax(int value) {
        mana.DecreaseMax(value);
        onLivesChange.Invoke();
    }
    // // // // // // // // // // // //
    // ENERGY
    public void IncreaseEnergy(int value) {
        energy.Increase(value);
        onEnergyChange.Invoke();
    }
    public void DecreaseEnergy(int value) {
        energy.Decrease(value);
        onEnergyChange.Invoke();
    }
    // // // // // // // // // // // //
    // EXPERIENCE
    public void IncreaseExp(int value) {
        exp.Increase(value);
        if (exp.value >= exp.valueMax) {
            exp.value = 0;
            IncreaseLevel();
        }
        onExpChange.Invoke();
    }
    public void DecreaseExp(int value) {
        exp.Decrease(value);
        onExpChange.Invoke();
    }
    public void IncreaseExpMax(int value) {
        exp.IncreaseMax(value);
        onLivesChange.Invoke();
    }
    public void DecreaseExpMax(int value) {
        exp.DecreaseMax(value);
        onLivesChange.Invoke();
    }
    // // // // // // // // // // // //
    // LEVEL
    public void IncreaseLevel() {
        level.Increase(1);
        onLevelChange.Invoke();
    }
    // // // // // // // // // // // //
    // GOLD
    public void IncreaseGold(int value) {
        gold.Increase(value);
        onGoldChange.Invoke();
    }
    public void DecreaseGold(int value) {
        gold.Decrease(value);
        onGoldChange.Invoke();
    }
}
