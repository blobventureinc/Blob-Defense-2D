using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AttributeManager player;
    [SerializeField] private GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health.value <= 0) {
            Time.timeScale = 0.00001f;
            GameOverUI.SetActive(true);
        }
    }
}
