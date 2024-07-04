using System;
using UnityEngine;

public class UpgradesModel: MonoBehaviour
{
    private int _clickPrice = EntryPoint.Instance.PlayerData.ClickPrice;
    private int _clickXpPrice = EntryPoint.Instance.PlayerData.ClickXpPrice;
    private int _lvlForUpgradeClickPrice = EntryPoint.Instance.PlayerData.LvlForUpgradeClickPrice;
    private int _lvlForUpgradeClickXpPrice = EntryPoint.Instance.PlayerData.LvlForUpgradeClickXpPrice;
    private int _upgradeClickXpCount = EntryPoint.Instance.PlayerData.UpgradeXpCount;
    private int _upgradeClickPrice = EntryPoint.Instance.PlayerData.UpgradeClickPriceCount;
    private int _priceUpgradeMoneyClickClickPrice = 30;
    private int _priceUpgradeXpClickClickPrice = 30;
    
    public int UpgradeClickPrice
    {
        get => _upgradeClickPrice;
        set => _upgradeClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    
    public int UpgradeClickXpPrice
    {
        get => _upgradeClickXpCount;
        set => _upgradeClickXpCount = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    
    public int UpgradePriceForUpgradeMoneyClick
    {
        get => _priceUpgradeMoneyClickClickPrice;
        set => _priceUpgradeMoneyClickClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    
    public int UpgradePriceForUpgradeXpClick
    {
        get => _priceUpgradeXpClickClickPrice;
        set => _priceUpgradeXpClickClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
    }
    
    public int GetLvlForUpgradeClickPrice()
    {
        return _lvlForUpgradeClickPrice;
    }
    
    public int GetLvlForUpgradeXpClickPrice()
    {
        return _lvlForUpgradeClickXpPrice;
    }
    
    public int GetClickPrice()
    {
        return _clickPrice;
    }

    public int GetClickXpPrice()
    {
        return _clickXpPrice;
    }
    
    public void IncrementClickPrice(int clickPriceIncrementCount)
    {
        _clickPrice += clickPriceIncrementCount;
    }

    public void IncrementClickXpPrice(int clickXpPriceIncrementCount)
    {
        _clickXpPrice += clickXpPriceIncrementCount;
    }

    public void IncrementLvlForUpgradeClick(int count)
    {
        _lvlForUpgradeClickPrice += count;
    }
    
    public void IncrementLvlForUpgradeXpClick(int count)
    {
        _lvlForUpgradeClickXpPrice += count;
    }
}
