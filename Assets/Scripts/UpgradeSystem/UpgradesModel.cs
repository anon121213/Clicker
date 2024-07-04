using UnityEngine;

public class UpgradesModel: MonoBehaviour
{
    private int _clickPrice = 1;
    private int _clickXpPrice = 1;
    private int _lvlForUpgradeClickPrice = 1;
    private int _lvlForUpgradeClickXpPrice = 1;

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
