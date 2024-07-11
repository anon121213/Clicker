using PopUp.Factory;
using UpgradeSystem;

namespace ClickSystem
{
    public class ClickerModel
    {
        public int Money;
     
        public ClickerModel(ClickerView clickerView, UpgradesModel upgradesModel, IPopUpFactory popUpFactory, int money)
        {
            Money = money;
            
            new ClickerPresenter(this, clickerView, upgradesModel, popUpFactory);
        }
        
        public int GetMoneyCount()
        {
            return Money;
        }

        public void IncrementMoneyCount(int clickPrice)
        {
            Money += clickPrice;
        }

        public void DecrimentMoneyCount(int decrimentValue)
        {
            if (Money - decrimentValue >= 0)
            {
                Money = Money - decrimentValue;
            }
        }
    }
}
