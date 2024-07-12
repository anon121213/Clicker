using BootStrap.Data;
using ClickSystem;
using LevelSystem;
using UnityEngine;
using UpgradeSystem;

namespace VContainer
{
    public class SavesHandler : MonoBehaviour, ISavedProgress
    {
        [Inject] private ClickerModel _clickerModel;
        [Inject] private LevelModel _levelModel;
        [Inject] private UpgradesMoneyModel _upgradesMoneyModel;
        [Inject] private LevelUpgradesModel _levelUpgradesModel;
        
        public void LoadProgress(PlayerProgres progress)
        {
            _clickerModel.AddMoney(progress.Money);
            
            _levelModel.AddLvL(progress.CurrentLvl);
            _levelModel.AddClicksForNewLvl(progress.ClicksForNewLvl);
            _levelModel.AddXp(progress.CurrentXp);

            _upgradesMoneyModel.AddClickPrice(progress.ClickPrice);
            _levelUpgradesModel.AddClickXpPrice(progress.ClickXpPrice);
            _upgradesMoneyModel.AddLvlForUpgradeClickPrice(progress.LvlForUpgradeClickPrice);
            _levelUpgradesModel.AddLvlForUpgradeClickXpPrice(progress.LvlForUpgradeClickXpPrice);
            _upgradesMoneyModel.AddUpgradeClickPrice(progress.UpgradeClickPrice);
            _levelUpgradesModel.AddUpgradeClickXpPrice(progress.UpgradeClickXpCount);
            _upgradesMoneyModel.AddUpgradePriceForUpgradeMoneyClick(progress.PriceForUpgradeMoneyClick);
            _levelUpgradesModel.AddPriceForUpgradeXpClick(progress.PriceForUpgradeXpClick);
        }

        public void UpdateProgress(PlayerProgres progress)
        {
            progress.Money = _clickerModel.Money;
            
            progress.CurrentLvl = _levelModel.CurrentLvL;
            progress.ClicksForNewLvl = _levelModel.ClicksForNewLvL;
            progress.CurrentXp = _levelModel.CurrentXp;
            
            progress.ClickPrice = _upgradesMoneyModel.ClickPrice;
            progress.ClickXpPrice = _levelUpgradesModel.ClickXpPrice;
            progress.LvlForUpgradeClickPrice = _upgradesMoneyModel.LvlForUpgradeClickPrice;
            progress.LvlForUpgradeClickXpPrice = _levelUpgradesModel.LvlForUpgradeClickXpPrice;
            progress.UpgradeClickXpCount = _upgradesMoneyModel.UpgradeClickPrice;
            progress.UpgradeClickPrice = _levelUpgradesModel.UpgradeClickXpPrice;
            progress.PriceForUpgradeMoneyClick = _upgradesMoneyModel.PriceForUpgradeMoneyClick;
            progress.PriceForUpgradeXpClick = _levelUpgradesModel.PriceForUpgradeXpClick;
        }

        private void OnDisable()
        {
            /*_clickerPresenter.Disable();
            _levelPresenter.Disable();
            _upgradesPresentor.Disable();*/
        }
    }
}