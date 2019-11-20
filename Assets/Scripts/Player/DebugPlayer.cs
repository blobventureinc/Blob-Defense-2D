using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayer : MonoBehaviour
{
    [SerializeField] private Player player;

    // // // // // // // // // // // //
    // LIVES
    public void IncreaseLives(int value) {
        player.lives.Increase(value);
    }
    public void DecreaseLives(int value) {
        player.lives.Decrease(value);
    }
    public void IncreaseLivesMax(int value) {
        player.lives.IncreaseMax(value);
    }
    public void DecreaseLivesMax(int value) {
        player.lives.DecreaseMax(value);
    }
    // // // // // // // // // // // //
    // MANA
    public void IncreaseMana(int value) {
        player.mana.Increase(value);
    }
    public void DecreaseMana(int value) {
        player.mana.Decrease(value);
    }
    public void IncreaseManaMax(int value) {
        player.mana.IncreaseMax(value);
    }
    public void DecreaseManaMax(int value) {
        player.mana.DecreaseMax(value);
    }
    // // // // // // // // // // // //
    // ENERGY
    public void IncreaseEnergy(int value) {
        player.energy.Increase(value);
    }
    public void DecreaseEnergy(int value) {
        player.energy.Decrease(value);
    }
    // // // // // // // // // // // //
    // EXPERIENCE
    public void IncreaseExp(int value) {
        player.exp.Increase(value);
        if (player.exp.value >= player.exp.valueMax) {
            player.exp.value = 0;
            IncreaseLevel();
        }
    }
    public void DecreaseExp(int value) {
        player.exp.Decrease(value);
    }
    public void IncreaseExpMax(int value) {
        player.exp.IncreaseMax(value);
    }
    public void DecreaseExpMax(int value) {
        player.exp.DecreaseMax(value);
    }
    // // // // // // // // // // // //
    // LEVEL
    public void IncreaseLevel() {
        player.level.Increase(1);
    }
    // // // // // // // // // // // //
    // GOLD
    public void IncreaseGold(int value) {
        player.gold.Increase(value);
    }
    public void DecreaseGold(int value) {
        player.gold.Decrease(value);
    } 
}
