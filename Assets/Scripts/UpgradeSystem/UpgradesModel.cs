using UnityEngine;

public class UpgradesModel: MonoBehaviour
{
    private int _clickPrice = EntryPoint.Instance.PlayerData.ClickPrice;
    private int _clickXpPrice = EntryPoint.Instance.PlayerData.ClickXpPrice;
    private int _lvlForUpgradeClickPrice = EntryPoint.Instance.PlayerData.LvlForUpgradeClickPrice;
    private int _lvlForUpgradeClickXpPrice = EntryPoint.Instance.PlayerData.LvlForUpgradeClickXpPrice;

    public int LvlForUpgradeClickXpPrice
    {
        get => _lvlForUpgradeClickXpPrice;
        set => _lvlForUpgradeClickXpPrice += value < 0 ? 0 : value;
    }

    public int LvlForUpgradeClickPrice
    {
        get => _lvlForUpgradeClickPrice;
        set => _lvlForUpgradeClickPrice += value < 0 ? 0 : value;
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
}
