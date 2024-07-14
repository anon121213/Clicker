using ClickSystem;
using LevelSystem;
using UnityEngine;
using UpgradeSystem.Models;

namespace UpgradeSystem.Services
{
    public class UpgradeClickPriceService : IUpgradeClickPriceService
    {
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;
        private readonly IClickerModel _clickerModel;
        private readonly ILevelModel _levelModel;

        public UpgradeClickPriceService(IUpgradesMoneyModel upgradesMoneyModel, IClickerModel clickerModel, ILevelModel levelModel)
        {
            _upgradesMoneyModel = upgradesMoneyModel;
            _clickerModel = clickerModel;
            _levelModel = levelModel;
        }
        
        public void TryUpgrade()
        {
            if (_upgradesMoneyModel.TryAddLvlForUpgradeClickPrice(_upgradesMoneyModel.LvlForUpgradeClickPrice, _levelModel.CurrentLvL, 1) 
                && _clickerModel.TryRemoveMoney(_upgradesMoneyModel.PriceForUpgradeMoneyClick))
            {
                _upgradesMoneyModel.AddClickPrice(_upgradesMoneyModel.UpgradeClickPrice);
                _upgradesMoneyModel.AddUpgradeClickPrice((int)Mathf.Round(_upgradesMoneyModel.UpgradeClickPrice * 1.5f));
                
                _upgradesMoneyModel.AddUpgradePriceForUpgradeMoneyClick(_upgradesMoneyModel.PriceForUpgradeMoneyClick);
            }
        }
    }
}