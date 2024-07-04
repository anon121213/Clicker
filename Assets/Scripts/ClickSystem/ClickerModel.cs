public class ClickerModel
{
    private int _money = EntryPoint.Instance.PlayerData.Money;

    public int GetMoneyCount()
    {
        return _money;
    }

    public void IncrementMoneyCount(int clickPrice)
    {
        _money += clickPrice;
    }

    public void DecrimentMoneyCount(int decrimentValue)
    {
        if (_money - decrimentValue >= 0)
        {
            _money = _money - decrimentValue;
        }
    }
}
