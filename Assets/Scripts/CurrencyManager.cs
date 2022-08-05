using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    public int currentCurrency;

    [SerializeField] private UIManager uıManager;

    public void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseCurrency(int amount)
    {
        currentCurrency += amount;
        uıManager.UpdateCurrencyText();
    }
    
}
