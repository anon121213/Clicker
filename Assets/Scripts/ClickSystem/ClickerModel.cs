public class ClickerModel
{
    private int _clickCount = 0;
    private int _clickPrice = 1;

    public int GetClickCount()
    {
        return _clickCount;
    }

    public int GetClickPrice()
    {
        return _clickPrice;
    }

    public void IncrementClickCount(int clickPrice)
    {
        _clickCount += clickPrice;
    }

    public void IncrementClickPrice(int clickPriceIncrement)
    {
        _clickPrice += clickPriceIncrement;
    }
}
