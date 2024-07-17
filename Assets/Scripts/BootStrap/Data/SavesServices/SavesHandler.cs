using BootStrap.Data.StaticData;
using ClickSystem;
using LevelSystem;
using UnityEngine;
using UpgradeSystem.Models;
using VContainer;

namespace BootStrap.Data.SavesServices
{
    public class SavesHandler : MonoBehaviour, ISavedProgress
    {
        private IClickerModel _clickerModel;
        private ILevelModel _levelModel;
        private IUpgradesMoneyModel _upgradesMoneyModel;
        private ILevelUpgradesModel _levelUpgradesModel;
        
        [Inject]
        public void Inject(IClickerModel clickerModel,
            ILevelModel levelModel,
            IUpgradesMoneyModel upgradesMoneyModel,
            ILevelUpgradesModel levelUpgradesModel)
        {
            _clickerModel = clickerModel;
            _levelModel = levelModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _levelUpgradesModel = levelUpgradesModel;
        }
        
        public void LoadProgress(PlayerProgress progress)
        {
            _clickerModel.AddMoney(progress.Money);
            
            _levelModel.AddLvL(progress.CurrentLvl);
            _levelModel.AddClicksForNewLvl(progress.ClicksForNewLvl);
            _levelModel.AddXp(progress.CurrentXp);
            _levelModel.ChangeLvlCount(progress.AddLvlCount);

            _upgradesMoneyModel.AddClickPrice(progress.ClickPrice);
            _levelUpgradesModel.AddClickXpPrice(progress.ClickXpPrice);
            _upgradesMoneyModel.AddLvlForUpgradeClickPrice(progress.LvlForUpgradeClickPrice);
            _levelUpgradesModel.AddLvlForUpgradeClickXpPrice(progress.LvlForUpgradeClickXpPrice);
            _upgradesMoneyModel.AddUpgradeClickPrice(progress.UpgradeClickPrice);
            _levelUpgradesModel.AddUpgradeClickXpPrice(progress.UpgradeClickXpCount);
            _upgradesMoneyModel.AddUpgradePriceForUpgradeMoneyClick(progress.PriceForUpgradeMoneyClick);
            _levelUpgradesModel.AddPriceForUpgradeXpClick(progress.PriceForUpgradeXpClick);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.Money = _clickerModel.Money;
            
            progress.CurrentLvl = _levelModel.CurrentLvL;
            progress.ClicksForNewLvl = _levelModel.ClicksForNewLvL;
            progress.CurrentXp = _levelModel.CurrentXp;
            progress.AddLvlCount = _levelModel.AddLvlCount;
            
            progress.ClickPrice = _upgradesMoneyModel.ClickPrice;
            progress.ClickXpPrice = _levelUpgradesModel.ClickXpPrice;
            progress.LvlForUpgradeClickPrice = _upgradesMoneyModel.LvlForUpgradeClickPrice;
            progress.LvlForUpgradeClickXpPrice = _levelUpgradesModel.LvlForUpgradeClickXpPrice;
            progress.UpgradeClickXpCount = _upgradesMoneyModel.UpgradeClickPrice;
            progress.UpgradeClickPrice = _levelUpgradesModel.UpgradeClickXpPrice;
            progress.PriceForUpgradeMoneyClick = _upgradesMoneyModel.PriceForUpgradeMoneyClick;
            progress.PriceForUpgradeXpClick = _levelUpgradesModel.PriceForUpgradeXpClick;
        }
    }
}