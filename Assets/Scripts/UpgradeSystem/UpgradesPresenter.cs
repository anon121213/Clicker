using System;
using ClickSystem;
using UpgradeSystem.Models;
using UpgradeSystem.Services.Money;
using UpgradeSystem.Services.Xp;

namespace UpgradeSystem
{
    public class UpgradesPresenter: IDisposable
    {
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;
        private readonly IClickerModel _clickerModel;
        private readonly ILevelUpgradesModel _levelUpgradesModel;
        private readonly IUpgradeClickPriceService _upgradeClickPriceService;
        private readonly IUpgradeClickXpService _upgradeClickXpService;

        private UpgradesView _upgradeView;
        private ClickerView _clickerView;

        public UpgradesPresenter(IUpgradesMoneyModel upgradesMoneyModel,
            IClickerModel clickerModel,
            ILevelUpgradesModel levelUpgradesModel,
            IUpgradeClickPriceService upgradeClickPriceService,
            IUpgradeClickXpService upgradeClickXpService)
        {
            _upgradesMoneyModel = upgradesMoneyModel;
            _clickerModel = clickerModel;
            _levelUpgradesModel = levelUpgradesModel;
            _upgradeClickPriceService = upgradeClickPriceService;
            _upgradeClickXpService = upgradeClickXpService;
        }

        public void Constructor(UpgradesView upgradesView, ClickerView clickerView)
        {
            _upgradeView = upgradesView;
            _clickerView = clickerView;
        }

        public void Start()
        {
            _upgradesMoneyModel.OnValueChanged += UpdateUi;
            _levelUpgradesModel.OnValueChanged += UpdateUi;
            
            _upgradeView.UpgradeClickPriceButton.onClick.AddListener(UpgradeClickPrice);
            _upgradeView.UpgradeXpPriceButton.onClick.AddListener(UpgradeClickXp);

            UpdateUi();
        }

        private void UpgradeClickPrice() =>
            _upgradeClickPriceService.TryUpgrade();

        private void UpgradeClickXp() =>
            _upgradeClickXpService.TryUpgrade();

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

        public void Dispose()
        {
            _upgradeView.UpgradeClickPriceButton.onClick.RemoveAllListeners();
            _upgradeView.UpgradeXpPriceButton.onClick.RemoveAllListeners();
            
            _upgradesMoneyModel.OnValueChanged -= UpdateUi;
            _levelUpgradesModel.OnValueChanged -= UpdateUi;
        }
    }
}