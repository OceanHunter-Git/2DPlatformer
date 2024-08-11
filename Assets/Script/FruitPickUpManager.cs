using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPickUpManager : MonoBehaviour
{
    public static FruitPickUpManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int currentFruitAmount;

    public int extraLifeCost;
    // Start is called before the first frame update
    public void Start()
    {
        UIController.instance.FruitDisplay(currentFruitAmount);
    }
    public void AddFruitAmount(int amountToAdd)
    {
        currentFruitAmount += amountToAdd;
        AudioManager.instance.PlaySFXPitch(9);

        if (currentFruitAmount > extraLifeCost)
        {
            currentFruitAmount -= extraLifeCost;
            LifeController.instance.AddLife();
        }
        UIController.instance.FruitDisplay(currentFruitAmount);
    }
}
