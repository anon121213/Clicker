using System;
using UnityEngine;

public class PlayerData
{
    public static PlayerData Instance { get; private set; }

    private int _clickPrice = 1;
    private int _clickXpPrice = 1;
    private int _lvlForUpgradeClickPrice = 1;
    private int _lvlForUpgradeClickXpPrice = 1;
    private int _money = 0;
    private int _currentLvl = 1;
    private int _clicksForNewLvl = 100;
    private int _currentClicks = 0;
    private int _upgradeClickXpCount = 1;
    private int _upgradeClickPriceCount = 1;
    private int _priceUpgradeMoneyClickPrice = 30;
    private int _priceUpgradeXpClickPrice = 30;

    public int ClickPrice
    {
        get => _clickPrice;
        set => _clickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    
    public int ClickXpPrice
    {
        get => _clickXpPrice;
        set => _clickXpPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    public int LvlForUpgradeClickPrice
    {
        get => _lvlForUpgradeClickPrice;
        set => _lvlForUpgradeClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    public int LvlForUpgradeClickXpPrice
    {
        get => _lvlForUpgradeClickXpPrice;
        set => _lvlForUpgradeClickXpPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    public int Money
    {
        get => _money;
        set => _money = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    public int CurrentLvl
    {
        get => _currentLvl;
        set => _currentLvl = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    public int ClicksForNewLvl
    {
        get => _clicksForNewLvl;
        set => _clicksForNewLvl = Mathf.Clamp(value, 0, Int32.MaxValue);
    }

    public int CurrentClicks
    {
        get => _currentClicks;
        set => _currentClicks = Mathf.Clamp(value, 0, Int32.MaxValue);
    }

    public int UpgradeClickXpCount
    {
        get => _upgradeClickXpCount;
        set => _upgradeClickXpCount = Mathf.Clamp(value, 0, Int32.MaxValue);
    }

    public int UpgradeClickPriceCount
    {
        get => _upgradeClickPriceCount;
        set => _upgradeClickPriceCount = Mathf.Clamp(value, 0, Int32.MaxValue);
    }

    public int PriceUpgradeMoneyClickPrice
    {
        get => _priceUpgradeMoneyClickPrice;
        set => _priceUpgradeMoneyClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }

    public int PriceUpgradeXpClickPrice
    {
        get => _priceUpgradeXpClickPrice;
        set => _priceUpgradeXpClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    
    public PlayerData()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Trying to create another instance of singleton PlayerData!");
        }
    }
}