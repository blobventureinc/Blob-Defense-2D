using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerAttributes : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private Slider livesBar = null;
    [SerializeField] private Text livesText = null;
    [SerializeField] private Slider manaBar = null;
    [SerializeField] private Text manaText = null;
    [SerializeField] private Slider energyBar = null;
    [SerializeField] private Text energyText = null;

    // Start is called before the first frame update
    void Start()
    {
        livesBar.maxValue = player.maxLives;
        manaBar.maxValue = player.maxMana;
        energyBar.maxValue = player.maxEnergy;
        player = GameObject.Find("Player").GetComponent<Player>();
        player.onLivesChange.AddListener(UpdateLivesBar);
        player.onManaChange.AddListener(UpdateManaBar);
        player.onEnergyChange.AddListener(UpdateEnergyBar);
        UpdateLivesBar();
        UpdateEnergyBar();
        UpdateManaBar();
    }

    public void UpdateLivesBar() {
        livesBar.value = player.lives;
        livesText.text = "HP: " + player.lives.ToString()+" / "+player.maxLives.ToString();
    }
    public void UpdateManaBar() {
        manaBar.value = player.mana;
        manaText.text = "MP: " + player.mana.ToString() + " / " + player.maxMana.ToString();
    }
    public void UpdateEnergyBar() {
        energyBar.value = player.energy;
        energyText.text = "EN: "+player.energy.ToString() + "%";
    }
}
