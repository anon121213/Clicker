using ClickSystem;
using Hud;
using LevelSystem;
using UnityEngine;
using UpgradeSystem.Models;
using UpgradeSystem.Services;
using UpgradeSystem.Services.Xp;

namespace UpgradeSystem
{
    public class UpgradesPresenter: IPresentor
    {
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;
        private readonly IClickerModel _clickerModel;
        private readonly ILevelUpgradesModel _levelUpgradesModel;
        private readonly IUpgradeClickPriceService _upgradeClickPriceService;
        private readonly IUpgradeClickXpService _upgradeClickXpService;

        private readonly UpgradesView _upgradeView;
        private readonly ClickerView _clickerView;

        public UpgradesPresenter(UpgradesView upgradesView, ClickerView clickerView,
            IUpgradesMoneyModel upgradesMoneyModel, IClickerModel clickerModel,
            ILevelUpgradesModel levelUpgradesModel, ILevelModel levelModel,
            IUpgradeClickPriceService upgradeClickPriceService, IUpgradeClickXpService upgradeClickXpService)
        {
            _upgradeView = upgradesView;
            _clickerView = clickerView;
            _upgradesMoneyModel = upgradesMoneyModel;
            _clickerModel = clickerModel;
            _levelUpgradesModel = levelUpgradesModel;
            _upgradeClickPriceService = upgradeClickPriceService;
            _upgradeClickXpService = upgradeClickXpService;

            Start();
        }

        private void Start()
        {
            _upgradesMoneyModel.OnValueChanged += UpdateUi;
            _levelUpgradesModel.OnValueChanged += UpdateUi;
            
            _upgradeView.UpgradeClickPriceButton.onClick.AddListener(UpgradeClickPrice);
            _upgradeView.UpgradeXpPriceButton.onClick.AddListener(UpgradeClickXp);

            UpdateUi();
        }

        private void UpgradeClickPrice()
        {
            _upgradeClickPriceService.TryUpgrade();
        }

        private void UpgradeClickXp()
        {
            _upgradeClickXpService.TryUpgrade();
        }

        private void UpdateUi()
        {
            _clickerView.UpdateClickCount(_clickerModel.Money);
            _upgradeView.UpdateClickPrice(_upgradesMoneyModel.ClickPrice);
            _upgradeView.UpdateUpgradeClickMoney(_upgradesMoneyModel.PriceForUpgradeMoneyClick, _upgradesMoneyModel.UpgradeClickPrice);
            _upgradeView.UpdateUpgradeClickXp( _levelUpgradesModel.PriceForUpgradeXpClick,  _levelUpgradesModel.UpgradeClickXpPrice);
            _upgradeView.UpdateClickXpPrice( _levelUpgradesModel.ClickXpPrice);
            _upgradeView.UpdateNeedLvlForUpgradeMoneyClick(_upgradesMoneyModel.LvlForUpgradeClickPrice);
            _upgradeView.UpdateNeedLvlForUpgradeXpClick(_levelUpgradesModel.LvlForUpgradeClickXpPrice);
        }

        public void Disable()
        {
            _upgradesMoneyModel.OnValueChanged -= UpdateUi;
            _levelUpgradesModel.OnValueChanged -= UpdateUi;
        }
    }
}