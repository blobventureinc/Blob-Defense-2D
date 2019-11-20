using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Attribute
{
    public int value;
    public int valueMax;

    public UnityEvent onValueChange;

    // Constructor for Attributes without a maxValue
    public Attribute(int value) {
        this.value = value;
        onValueChange = new UnityEvent();
    }

    // Constructor for Attributes with a maxValue
    public Attribute(int value, int valueMax) {
        this.valueMax = valueMax;
        this.value = value;
        onValueChange = new UnityEvent();
    }

    public void Increase(int value) {
        this.value += value;
        if (valueMax != 0) {
            if (this.value >= valueMax) {
                this.value = valueMax;
            }
        }
        onValueChange.Invoke();
    }

    public void Decrease(int value) {
        this.value -= value;
        if (this.value <= 0) {
            this.value = 0;
        }
        onValueChange.Invoke();
    }

    public void IncreaseMax(int value) {
        valueMax += value;
        onValueChange.Invoke();
    }

    public void DecreaseMax(int value) {
        valueMax -= value;
        if (valueMax <= 0) {
            valueMax = 0;
        }
        onValueChange.Invoke();
    }
}
