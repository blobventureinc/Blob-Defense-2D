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

    public void Set(int value) {
        this.value = value;
        onValueChange.Invoke();
    }

    public void Increase(int value) {
        this.value += value;
        if (this.valueMax != 0) {
            if (this.value >= this.valueMax) {
                this.value = this.valueMax;
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

    public void SetMax(int value) {
        this.valueMax = value;
        onValueChange.Invoke();
    }

    public void IncreaseMax(int value) {
        this.valueMax += value;
        onValueChange.Invoke();
    }

    public void DecreaseMax(int value) {
        this.valueMax -= value;
        if (this.valueMax <= 0) {
            this.valueMax = 0;
        }
        onValueChange.Invoke();
    }

    public float GetValuePercent() {
        return (float) value / valueMax;
    }
}
