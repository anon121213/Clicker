using PopUp.Factory;
using UpgradeSystem;

namespace ClickSystem
{
    public class ClickerModel
    {
        private int Money;
     
        public ClickerModel(ClickerView clickerView, UpgradesModel upgradesModel, IPopUpFactory popUpFactory)
        {
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
