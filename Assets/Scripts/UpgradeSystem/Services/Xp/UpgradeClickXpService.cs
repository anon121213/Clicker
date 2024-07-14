using ClickSystem;
using LevelSystem;
using UnityEngine;

namespace UpgradeSystem.Services.Xp
{
    public class UpgradeClickXpService : IUpgradeClickXpService
    {
        private readonly ILevelUpgradesModel _levelUpgradesModel;
        private readonly IClickerModel _clickerModel;
        private readonly ILevelModel _levelModel;

        public UpgradeClickXpService(ILevelUpgradesModel levelUpgradesModel, IClickerModel clickerModel,
            ILevelModel levelModel)
        {
            _levelUpgradesModel = levelUpgradesModel;
            _clickerModel = clickerModel;
            _levelModel = levelModel;
        }
        
        public void TryUpgrade()
        {
            if (_levelUpgradesModel.TryAddLvlForUpgradeClickPrice(_levelUpgradesModel.LvlForUpgradeClickXpPrice, _levelModel.CurrentLvL, 1)
                && _clickerModel.TryRemoveMoney(_levelUpgradesModel.PriceForUpgradeXpClick))
            {
                _levelUpgradesModel.AddClickXpPrice( _levelUpgradesModel.UpgradeClickXpPrice);
                _levelUpgradesModel.AddUpgradeClickXpPrice((int)Mathf.Round( _levelUpgradesModel.UpgradeClickXpPrice * 1.5f));
                
                _levelUpgradesModel.AddPriceForUpgradeXpClick( _levelUpgradesModel.PriceForUpgradeXpClick); 
            }
        }
    }
}