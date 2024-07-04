using UnityEngine;

public class UpgradesModel: MonoBehaviour
{
    private int _clickPrice = 1;
    
    public int GetClickPrice()
    {
        return _clickPrice;
    }
    
    public void IncrementClickPrice(int clickPriceIncrement)
    {
        _clickPrice += clickPriceIncrement;
    }
}
