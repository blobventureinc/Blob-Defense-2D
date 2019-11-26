using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent onLivesChange;
    public UnityEvent onManaChange;
    public UnityEvent onEnergyChange;

    [Header("Total Lives")]
    [SerializeField] private int _lives = 10;
    [SerializeField] private int _maxLives = 10;

    [Header("Mana as (int) Total")]
    [SerializeField] private int _mana = 10;
    [SerializeField] private int _maxMana = 10;

    [Header("Energy as Percent")]
    [SerializeField] private int _energy = 100;
    [SerializeField] private int _maxEnergy = 100;

    // LIVES
    public int lives {
        get {
            return _lives;
        }
    }
    public int maxLives {
        get {
            return _maxLives;
        }
    }
    public void GainLives(int value) {
        _lives += value;
        if (_lives >= _maxLives) {
            _lives = _maxLives;
        }
        onLivesChange.Invoke();
    }
    public void LoseLives(int value) {
        _lives -= value;
        if (_lives <= 0) {
            _lives = 0;
        }
        onLivesChange.Invoke();
    }

    // MANA
    public int mana {
        get {
            return _mana;
        }
    }
    public int maxMana {
        get {
            return _maxMana;
        }
    }
    public void GainMana(int value) {
        _mana += value;
        if (_mana >= _maxMana) {
            _mana = _maxMana;
        }
        onManaChange.Invoke();
    }
    public void LoseMana(int value) {
        _mana -= value;
        if (_mana <= 0) {
            _mana = 0;
        }
        onManaChange.Invoke();
    }


    // ENERGY
    public int energy {
        get {
            return _energy;
        }
    }
    public int maxEnergy {
        get {
            return _maxEnergy;
        }
    }
    public void GainEnergy(int value) {
        _energy += value;
        if (_energy >= _maxEnergy) {
            _energy = _maxEnergy;
        }
        onEnergyChange.Invoke();
    }
    public void LoseEnergy(int value) {
        _energy -= value;
        if (_energy <= 0) {
            _energy = 0;
        }
        onEnergyChange.Invoke();
    }
}
