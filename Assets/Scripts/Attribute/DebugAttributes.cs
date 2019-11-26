using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAttributes : MonoBehaviour
{
    [SerializeField] private AttributeManager attributes;

    // // // // // // // // // // // //
    // LIVES
    public void IncreaseLives(int value) {
        attributes.health.Increase(value);
    }
    public void DecreaseLives(int value) {
        attributes.health.Decrease(value);
    }
    public void IncreaseLivesMax(int value) {
        attributes.health.IncreaseMax(value);
    }
    public void DecreaseLivesMax(int value) {
        attributes.health.DecreaseMax(value);
    }
    // // // // // // // // // // // //
    // MANA
    public void IncreaseMana(int value) {
        attributes.mana.Increase(value);
    }
    public void DecreaseMana(int value) {
        attributes.mana.Decrease(value);
    }
    public void IncreaseManaMax(int value) {
        attributes.mana.IncreaseMax(value);
    }
    public void DecreaseManaMax(int value) {
        attributes.mana.DecreaseMax(value);
    }
    // // // // // // // // // // // //
    // ENERGY
    public void IncreaseEnergy(int value) {
        attributes.energy.Increase(value);
    }
    public void DecreaseEnergy(int value) {
        attributes.energy.Decrease(value);
    }
    // // // // // // // // // // // //
    // EXPERIENCE
    public void IncreaseExp(int value) {
        attributes.exp.Increase(value);
    }
    public void DecreaseExp(int value) {
        attributes.exp.Decrease(value);
    }
    public void IncreaseExpMax(int value) {
        attributes.exp.IncreaseMax(value);
    }
    public void DecreaseExpMax(int value) {
        attributes.exp.DecreaseMax(value);
    }
    // // // // // // // // // // // //
    // LEVEL
    public void IncreaseLevel() {
        attributes.level.Increase(1);
    }
    // // // // // // // // // // // //
    // GOLD
    public void IncreaseGold(int value) {
        attributes.gold.Increase(value);
    }
    public void DecreaseGold(int value) {
        attributes.gold.Decrease(value);
    } 
}
