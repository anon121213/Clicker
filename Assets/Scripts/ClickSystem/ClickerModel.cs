using BootStrap.Data;
using PopUp.Factory;
using UnityEngine;
using UpgradeSystem;

namespace ClickSystem
{
    public class ClickerModel: ISavedProgress
    {
        private int _money = 0;
     
        public ClickerModel(ClickerView clickerView, UpgradesModel upgradesModel, IPopUpFactory popUpFactory)
        {
            new ClickerPresenter(this, clickerView, upgradesModel, popUpFactory);
            Debug.Log(upgradesModel);
        }
        
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

        public void LoadProgress(PlayerProgres progress)
        {
            _money = progress.Money;
        }

        public void UpdateProgress(PlayerProgres progres)
        {
            progres.Money = _money;
        }
    }
}
