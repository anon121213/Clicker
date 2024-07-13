using BootStrap.Data;
using ClickSystem;
using LevelSystem;
using UnityEngine;

namespace UpgradeSystem
{
    public class UpgradesPresenter: IPresentor
    {
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;
        private readonly IClickerModel _clickerModel;
        private readonly ILevelUpgradesModel _levelUpgradesModel;
        private readonly ILevelModel _levelModel;
        
        private readonly UpgradesView _upgradeView;
        private readonly ClickerView _clickerView;

        public UpgradesPresenter(UpgradesView upgradesView, ClickerView clickerView, IUpgradesMoneyModel upgradesMoneyModel,
            IClickerModel clickerModel, ILevelUpgradesModel levelUpgradesModel, ILevelModel levelModel)
        {
            _upgradeView = upgradesView;
            _clickerView = clickerView;
            _upgradesMoneyModel = upgradesMoneyModel;
            _clickerModel = clickerModel;
            _levelUpgradesModel = levelUpgradesModel;
            _levelModel = levelModel;
            
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
            if (_upgradesMoneyModel.TryAddLvlForUpgradeClickPrice(_upgradesMoneyModel.LvlForUpgradeClickPrice, _levelModel.CurrentLvL, 1) 
                && _clickerModel.TryRemoveMoney(_upgradesMoneyModel.PriceForUpgradeMoneyClick))
            {
                _upgradesMoneyModel.AddClickPrice(_upgradesMoneyModel.UpgradeClickPrice);
                _upgradesMoneyModel.AddUpgradeClickPrice((int)Mathf.Round(_upgradesMoneyModel.UpgradeClickPrice * 1.5f));
                
                _upgradesMoneyModel.AddUpgradePriceForUpgradeMoneyClick(_upgradesMoneyModel.PriceForUpgradeMoneyClick);
            }
        }

        private void UpgradeClickXp()
        {
            if (_levelUpgradesModel.TryAddLvlForUpgradeClickPrice(_levelUpgradesModel.LvlForUpgradeClickXpPrice, _levelModel.CurrentLvL, 1)
                && _clickerModel.TryRemoveMoney(_levelUpgradesModel.PriceForUpgradeXpClick))
            {
                _levelUpgradesModel.AddClickXpPrice( _levelUpgradesModel.UpgradeClickXpPrice);
                _levelUpgradesModel.AddUpgradeClickXpPrice((int)Mathf.Round( _levelUpgradesModel.UpgradeClickXpPrice * 1.5f));
                
                _levelUpgradesModel.AddPriceForUpgradeXpClick( _levelUpgradesModel.PriceForUpgradeXpClick); 
            }
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