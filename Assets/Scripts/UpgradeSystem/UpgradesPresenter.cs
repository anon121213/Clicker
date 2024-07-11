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
        
        private readonly UpgradesModel _upgradesModel;
        private readonly UpgradesView _upgradeView;
        private readonly ClickerView _clickerView;
        private readonly ClickerModel _clikerModel;
        private readonly LevelUpgradesModel _levelUpgradesModel;
        private readonly LevelModel _levelModel;

        public UpgradesPresenter(UpgradesView upgradesView, ClickerView clickerView, UpgradesModel upgradesModel,
            ClickerModel clickerModel, LevelUpgradesModel levelUpgradesModel, LevelModel levelModel)
        {
            _upgradeView = upgradesView;
            _clickerView = clickerView;
            _upgradesModel = upgradesModel;
            _clikerModel = clickerModel;
            _levelUpgradesModel = levelUpgradesModel;
            _levelModel = levelModel;
            Start();
        }
    
        private void Start()
        {
            _upgradesModel.OnValueChanged += UpdateUi;
            _levelUpgradesModel.OnValueChanged += UpdateUi;
            
            _upgradeView.UpgradeClickPriceButton.onClick.AddListener(UpgradeClickPrice);
            _upgradeView.UpgradeXpPriceButton.onClick.AddListener(UpgradeClickXp);
            
            _clickerView.UpdateClickCount(_clikerModel.Money);
            _upgradeView.UpdateClickPrice(_upgradesModel.ClickPrice);
            _upgradeView.UpdateUpgradeClickMoney(_upgradesModel.UpgradePriceForUpgradeMoneyClick, _upgradesModel.UpgradeClickPrice);
            _upgradeView.UpdateUpgradeClickXp(_upgradesModel.UpgradePriceForUpgradeXpClick, _upgradesModel.UpgradeClickXpPrice);
            _upgradeView.UpdateClickXpPrice(_upgradesModel.ClickXpPrice);
            _upgradeView.UpdateNeedLvlForUpgradeMoneyClick(_levelUpgradesModel.LvlForUpgradeClickPrice);
            _upgradeView.UpdateNeedLvlForUpgradeXpClick(_levelUpgradesModel.LvlForUpgradeClickXpPrice);
        }

        private void UpgradeClickPrice()
        {
            if (_levelUpgradesModel.LvlForUpgradeClickPrice <= _levelModel.CurrentLvL && _clikerModel.Money >= _upgradesModel.UpgradePriceForUpgradeMoneyClick)
            {
                PlaySFX.instance.PlayMusic(_buySound);
            
                _upgradesModel.AddClickPrice(_upgradesModel.UpgradeClickPrice);
                _upgradesModel.AddUpgradeClickPrice((int)Mathf.Round(_upgradesModel.UpgradeClickPrice * 1.5f));
            
                _clikerModel.RemoveMoney(_upgradesModel.UpgradePriceForUpgradeMoneyClick);
                _upgradesModel.AddUpgradePriceForUpgradeMoneyClick(_upgradesModel.UpgradePriceForUpgradeMoneyClick);
                _levelUpgradesModel.AddLvlForUpgradeClickPrice(1);
            }
            else
            {
                PlaySFX.instance.PlayMusic(_errorSound);
            }
        }

        private void UpgradeClickXp()
        {
            if (_levelUpgradesModel.LvlForUpgradeClickXpPrice <= _levelModel.CurrentLvL && _clikerModel.Money >= _upgradesModel.UpgradePriceForUpgradeXpClick)
            {
                PlaySFX.instance.PlayMusic(_buySound);
            
                _upgradesModel.AddClickXpPrice(_upgradesModel.UpgradeClickXpPrice);
                _upgradesModel.AddUpgradeClickXpPrice((int)Mathf.Round(_upgradesModel.UpgradeClickXpPrice * 1.5f));
            
                _clikerModel.RemoveMoney(_upgradesModel.UpgradePriceForUpgradeXpClick);
                _upgradesModel.AddUpgradePriceForUpgradeXpClick(_upgradesModel.UpgradePriceForUpgradeXpClick); 
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
            _upgradeView.UpdateClickPrice(_upgradesModel.ClickPrice);
            _upgradeView.UpdateUpgradeClickMoney(_upgradesModel.UpgradePriceForUpgradeMoneyClick, _upgradesModel.UpgradeClickPrice);
            _upgradeView.UpdateUpgradeClickXp(_upgradesModel.UpgradePriceForUpgradeXpClick, _upgradesModel.UpgradeClickXpPrice);
            _upgradeView.UpdateClickXpPrice(_upgradesModel.ClickXpPrice);
            _upgradeView.UpdateNeedLvlForUpgradeMoneyClick(_levelUpgradesModel.LvlForUpgradeClickPrice);
            _upgradeView.UpdateNeedLvlForUpgradeXpClick(_levelUpgradesModel.LvlForUpgradeClickXpPrice);
        }

        public void Disable()
        {
            _upgradesModel.OnValueChanged -= UpdateUi;
            _levelUpgradesModel.OnValueChanged -= UpdateUi;
        }
    }
}