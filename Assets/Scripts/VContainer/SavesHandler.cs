using BootStrap.Data;
using ClickSystem;
using LevelSystem;
using ModelsFactory;
using UnityEngine;
using UpgradeSystem;

namespace VContainer
{
    public class SavesHandler : MonoBehaviour, ISavedProgress
    {
        [Inject] private IPresentorsFactory _presentorsFactory;

        private ClickerPresenter _clickerPresenter;
        private LevelPresenter _levelPresenter;
        private UpgradesPresenter _upgradesPresentor;
        
        [Inject] private ClickerModel _clickerModel;
        [Inject] private LevelModel _levelModel;
        [Inject] private UpgradesModel _upgradesModel;
        [Inject] private LevelUpgradesModel _levelUpgradesModel;
        
        private void Start()
        {
            CreatePresentors();
        }

        private void CreatePresentors()
        {
            _clickerPresenter = _presentorsFactory.CreateClickPresentor();
            _levelPresenter = _presentorsFactory.CreateLevelPresentor();
            _upgradesPresentor = _presentorsFactory.CreateUpgradesPresentor();
        }

        public void LoadProgress(PlayerProgres progress)
        {
            _clickerModel.AddMoney(progress.Money);
            
            _levelModel.AddLvL(progress.CurrentLvl);
            _levelModel.AddClicksForNewLvl(progress.ClicksForNewLvl);
            _levelModel.AddXp(progress.CurrentXp);

            _upgradesModel.AddClickPrice(progress.ClickPrice);
            _upgradesModel.AddClickXpPrice(progress.ClickXpPrice);
            _levelUpgradesModel.AddLvlForUpgradeClickPrice(progress.LvlForUpgradeClickPrice);
            _levelUpgradesModel.AddLvlForUpgradeClickXpPrice(progress.LvlForUpgradeClickXpPrice);
            _upgradesModel.AddUpgradeClickPrice(progress.UpgradeClickPrice);
            _upgradesModel.AddUpgradeClickXpPrice(progress.UpgradeClickXpCount);
            _upgradesModel.AddUpgradePriceForUpgradeMoneyClick(progress.PriceUpgradeMoneyClickClickPrice);
            _upgradesModel.AddUpgradePriceForUpgradeXpClick(progress.PriceUpgradeXpClickClickPrice);
        }

        public void UpdateProgress(PlayerProgres progress)
        {
            progress.Money = _clickerModel.Money;
            
            progress.CurrentLvl = _levelModel.CurrentLvL;
            progress.ClicksForNewLvl = _levelModel.ClicksForNewLvL;
            progress.CurrentXp = _levelModel.CurrentXp;
            
            progress.ClickPrice = _upgradesModel.ClickPrice;
            progress.ClickXpPrice = _upgradesModel.ClickXpPrice;
            progress.LvlForUpgradeClickPrice = _levelUpgradesModel.LvlForUpgradeClickPrice;
            progress.LvlForUpgradeClickXpPrice = _levelUpgradesModel.LvlForUpgradeClickXpPrice;
            progress.UpgradeClickXpCount = _upgradesModel.UpgradeClickPrice;
            progress.UpgradeClickPrice = _upgradesModel.UpgradeClickXpPrice;
            progress.PriceUpgradeMoneyClickClickPrice = _upgradesModel.UpgradePriceForUpgradeMoneyClick;
            progress.PriceUpgradeXpClickClickPrice = _upgradesModel.UpgradePriceForUpgradeXpClick;
        }

        private void OnDisable()
        {
            _clickerPresenter.Disable();
            _levelPresenter.Disable();
            _upgradesPresentor.Disable();
        }
    }
}