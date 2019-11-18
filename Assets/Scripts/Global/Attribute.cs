using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Attribute
{
    public int value;
    public int valueMax;

    // Constructor for Attributes without a maxValue
    public Attribute(int value) {
        this.value = value;
    }

    // Constructor for Attributes with a maxValue
    public Attribute(int value, int valueMax) {
        this.valueMax = valueMax;
        this.value = value;
    }

    public void Increase(int value) {
        this.value += value;
        if (valueMax != 0) {
            if (this.value >= valueMax) {
                this.value = valueMax;
            }
        }
    }

    public void Decrease(int value) {
        this.value -= value;
        if (this.value <= 0) {
            this.value = 0;
        }
    }

    public void IncreaseMax(int value) {
        valueMax += value;
    }

    public void DecreaseMax(int value) {
        valueMax -= value;
        if (valueMax <= 0) {
            valueMax = 0;
        }
    }
}
