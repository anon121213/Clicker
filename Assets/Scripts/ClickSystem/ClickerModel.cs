public class ClickerModel
{
    private int _clickCount = 0;

    public int GetClickCount()
    {
        return _clickCount;
    }

    public void IncrementClickCount(int clickPrice)
    {
        _clickCount += clickPrice;
    }
}
