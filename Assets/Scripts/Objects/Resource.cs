using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string type = null;
    public int goldValue;
    public int energyDrainValue;
    public int duration;

    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private Sprite[] spriteStates = new Sprite[3];
    private int currentState = 0;

    public void Destroy()
    {
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().Play("Go", 0, 0);
        }
        if (GetComponent<ParticleSystem>() != null)
        {
            GetComponent<ParticleSystem>().Play();
        }
        if (currentState <= spriteStates.Length - 1)
        {
            spriteRenderer.sprite = spriteStates[currentState];
            currentState++;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
}
