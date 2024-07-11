using ClickSystem;
using LevelSystem;
using Settings;
using UnityEngine;

namespace UpgradeSystem
{
    public class UpgradesPresenter : MonoBehaviour
    {
        [SerializeField] private AudioClip _errorSound;
        [SerializeField] private AudioClip _buySound;
        
        private readonly UpgradesModel _upgradesModel;
        private readonly UpgradesView _upgradeUpgradesView;
        private readonly ClickerView _clickerView;
        private readonly ClickerModel _clikerModel;
        private readonly LevelModel _levelModel;

        public UpgradesPresenter(UpgradesView upgradesView, ClickerView clickerView, UpgradesModel upgradesModel,
            ClickerModel clickerModel, LevelModel levelModel)
        {
            _upgradeUpgradesView = upgradesView;
            _clickerView = clickerView;
            _upgradesModel = upgradesModel;
            _clikerModel = clickerModel;
            _levelModel = levelModel;
        }
    
        private void Start()
        {
            _upgradeUpgradesView.UpdateClickPrice(_upgradesModel.GetClickPrice());
            _clickerView.UpdateClickCount(_clikerModel.GetMoneyCount());
            _upgradeUpgradesView.UpdateUpgradeClickMoney(_upgradesModel.UpgradePriceForUpgradeMoneyClick, _upgradesModel.UpgradeClickPrice);
            _upgradeUpgradesView.UpdateUpgradeClickXp(_upgradesModel.UpgradePriceForUpgradeXpClick, _upgradesModel.UpgradeClickXpPrice);
            _upgradeUpgradesView.UpdateClickXpPrice(_upgradesModel.GetClickXpPrice());
            _upgradeUpgradesView.UpdateNeedLvlForUpgradeMoneyClick(_upgradesModel.GetLvlForUpgradeClickPrice());
            _upgradeUpgradesView.UpdateNeedLvlForUpgradeXpClick(_upgradesModel.GetLvlForUpgradeXpClickPrice());
        }

        private void UpgradeClickPrice()
        {
            if (_upgradesModel.GetLvlForUpgradeClickPrice() <= _levelModel.GetCurrentLvL() && _clikerModel.GetMoneyCount() >= _upgradesModel.UpgradePriceForUpgradeMoneyClick)
            {
                PlaySFX.instance.PlayMusic(_buySound);
            
                _upgradesModel.IncrementClickPrice(_upgradesModel.UpgradeClickPrice);
                _upgradesModel.UpgradeClickPrice = (int)Mathf.Round(_upgradesModel.UpgradeClickPrice * 1.5f);
            
                _clikerModel.DecrimentMoneyCount(_upgradesModel.UpgradePriceForUpgradeMoneyClick);
                _upgradesModel.UpgradePriceForUpgradeMoneyClick *= 2; 
                _upgradesModel.IncrementLvlForUpgradeClick(1);
            
                _upgradeUpgradesView.UpdateClickPrice(_upgradesModel.GetClickPrice());
                _clickerView.UpdateClickCount(_clikerModel.GetMoneyCount());
                _upgradeUpgradesView.UpdateUpgradeClickMoney(_upgradesModel.UpgradePriceForUpgradeMoneyClick, _upgradesModel.UpgradeClickPrice);
                _upgradeUpgradesView.UpdateNeedLvlForUpgradeMoneyClick(_upgradesModel.GetLvlForUpgradeClickPrice());
            }
            else
            {
                PlaySFX.instance.PlayMusic(_errorSound);
            }
        }

        private void UpgradeClickXP()
        {
            if (_upgradesModel.GetLvlForUpgradeXpClickPrice() <= _levelModel.GetCurrentLvL() && _clikerModel.GetMoneyCount() >= _upgradesModel.UpgradePriceForUpgradeXpClick)
            {
                PlaySFX.instance.PlayMusic(_buySound);
            
                _upgradesModel.IncrementClickXpPrice(_upgradesModel.UpgradeClickXpPrice);
                _upgradesModel.UpgradeClickXpPrice = (int)Mathf.Round(_upgradesModel.UpgradeClickXpPrice * 1.5f);
            
                _clikerModel.DecrimentMoneyCount(_upgradesModel.UpgradePriceForUpgradeXpClick);
                _upgradesModel.UpgradePriceForUpgradeXpClick *= 2; 
                _upgradesModel.IncrementLvlForUpgradeXpClick(1);
            
                _upgradeUpgradesView.UpdateClickXpPrice(_upgradesModel.GetClickXpPrice());
                _clickerView.UpdateClickCount(_clikerModel.GetMoneyCount());
                _upgradeUpgradesView.UpdateUpgradeClickXp(_upgradesModel.UpgradePriceForUpgradeXpClick, _upgradesModel.UpgradeClickXpPrice);
                _upgradeUpgradesView.UpdateNeedLvlForUpgradeXpClick(_upgradesModel.GetLvlForUpgradeXpClickPrice());
            }
            else
            {
                PlaySFX.instance.PlayMusic(_errorSound);
            }
        }
    }
}