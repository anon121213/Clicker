using ClickSystem;
using LevelSystem;
using Settings;
using UnityEngine;

namespace UpgradeSystem
{
    public class UpgradesPresenter
    {
        [SerializeField] private AudioClip _errorSound;
        [SerializeField] private AudioClip _buySound;
        
        private readonly UpgradesMoneyModel _upgradesMoneyModel;
        private readonly UpgradesView _upgradeView;
        private readonly ClickerView _clickerView;
        private readonly ClickerModel _clikerModel;
        private readonly LevelUpgradesModel _levelUpgradesModel;
        private readonly LevelModel _levelModel;

        public UpgradesPresenter(UpgradesView upgradesView, ClickerView clickerView, UpgradesMoneyModel upgradesMoneyModel,
            ClickerModel clickerModel, LevelUpgradesModel levelUpgradesModel, LevelModel levelModel)
        {
            _upgradeView = upgradesView;
            _clickerView = clickerView;
            _upgradesMoneyModel = upgradesMoneyModel;
            _clikerModel = clickerModel;
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
            
            _clickerView.UpdateClickCount(_clikerModel.Money);
            _upgradeView.UpdateClickPrice(_upgradesMoneyModel.ClickPrice);
            _upgradeView.UpdateUpgradeClickMoney(_upgradesMoneyModel.PriceForUpgradeMoneyClick, _upgradesMoneyModel.UpgradeClickPrice);
            _upgradeView.UpdateUpgradeClickXp(_levelUpgradesModel.PriceForUpgradeXpClick, _levelUpgradesModel.UpgradeClickXpPrice);
            _upgradeView.UpdateClickXpPrice(_levelUpgradesModel.ClickXpPrice);
            _upgradeView.UpdateNeedLvlForUpgradeMoneyClick(_upgradesMoneyModel.LvlForUpgradeClickPrice);
            _upgradeView.UpdateNeedLvlForUpgradeXpClick(_levelUpgradesModel.LvlForUpgradeClickXpPrice);
        }

        private void UpgradeClickPrice()
        {
            if (_upgradesMoneyModel.LvlForUpgradeClickPrice <= _levelModel.CurrentLvL && _clikerModel.Money >= _upgradesMoneyModel.PriceForUpgradeMoneyClick)
            {
                PlaySFX.instance.PlayMusic(_buySound);
            
                _upgradesMoneyModel.AddClickPrice(_upgradesMoneyModel.UpgradeClickPrice);
                _upgradesMoneyModel.AddUpgradeClickPrice((int)Mathf.Round(_upgradesMoneyModel.UpgradeClickPrice * 1.5f));
            
                _clikerModel.RemoveMoney(_upgradesMoneyModel.PriceForUpgradeMoneyClick);
                _upgradesMoneyModel.AddUpgradePriceForUpgradeMoneyClick(_upgradesMoneyModel.PriceForUpgradeMoneyClick);
                _upgradesMoneyModel.AddLvlForUpgradeClickPrice(1);
            }
            else
            {
                PlaySFX.instance.PlayMusic(_errorSound);
            }
        }

        private void UpgradeClickXp()
        {
            if (_levelUpgradesModel.LvlForUpgradeClickXpPrice <= _levelModel.CurrentLvL && _clikerModel.Money >= _levelUpgradesModel.PriceForUpgradeXpClick)
            {
                PlaySFX.instance.PlayMusic(_buySound);
            
                _levelUpgradesModel.AddClickXpPrice( _levelUpgradesModel.UpgradeClickXpPrice);
                _levelUpgradesModel.AddUpgradeClickXpPrice((int)Mathf.Round( _levelUpgradesModel.UpgradeClickXpPrice * 1.5f));
            
                _clikerModel.RemoveMoney(_levelUpgradesModel.PriceForUpgradeXpClick);
                _levelUpgradesModel.AddPriceForUpgradeXpClick( _levelUpgradesModel.PriceForUpgradeXpClick); 
                _levelUpgradesModel.AddLvlForUpgradeClickXpPrice(1);
            }
            else
            {
                PlaySFX.instance.PlayMusic(_errorSound);
            }
        }

        private void UpdateUi()
        {
            _clickerView.UpdateClickCount(_clikerModel.Money);
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