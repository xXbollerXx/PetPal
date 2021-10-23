using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    public animalTap animal;
    [SerializeField]
    float StartingAmount = 100.55f;
    [SerializeField]
    TextMeshProUGUI CurrencyDisplay;

    private void Start()
    {
        if(!Instance)
        {
            Instance = this;
        }
        if (!animal)
        {
            animal = animalTap.Instance;
        }

        if (!CurrencyDisplay)
        {
            Debug.LogError("Need to assign Text object to the Currency Manager");
            return;
        }

        AddCurrency(StartingAmount);
        UpdateUI();
    }
    public void AddCurrency(float Amount)
    {
        animal.evolutionProgress += Amount;
       
        UpdateUI();
    }
    public bool TryToRemoveCurrency(float Amount)
    {
        var Temp = animal.evolutionProgress - Amount; 
        if (Temp < 0)
        {
            Debug.Log("no money");
            return false;
        }

        animal.evolutionProgress = Temp;
      
        UpdateUI();
        return true;
    }

    void UpdateUI()
    {
        CurrencyDisplay.text = animal.evolutionProgress.ToString();
    }

}
