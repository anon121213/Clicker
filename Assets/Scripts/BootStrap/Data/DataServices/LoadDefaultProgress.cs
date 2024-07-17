using BootStrap.Data.StaticData;

namespace BootStrap.Data.DataServices
{
    public class LoadDefaultProgress : ILoadDefaultProgress
    {
        private readonly IStaticDataProvider _staticDataProvider;
        
        public LoadDefaultProgress(IStaticDataProvider staticDataProvider) =>
            _staticDataProvider = staticDataProvider;

        public void SetDefaultSettings(PlayerProgress progress)
        {
            progress.Money = _staticDataProvider.DefaultPlayerSettings.Money;
            progress.ClickPrice = _staticDataProvider.DefaultPlayerSettings.ClickPrice;
            progress.CurrentLvl = _staticDataProvider.DefaultPlayerSettings.CurrentLvl;
            progress.CurrentXp = _staticDataProvider.DefaultPlayerSettings.CurrentXp;
            progress.UpgradeClickPrice = _staticDataProvider.DefaultPlayerSettings.UpgradeClickPrice;
            progress.ClickXpPrice = _staticDataProvider.DefaultPlayerSettings.ClickXpPrice;
            progress.ClicksForNewLvl = _staticDataProvider.DefaultPlayerSettings.ClicksForNewLvl;
            progress.UpgradeClickXpCount = _staticDataProvider.DefaultPlayerSettings.UpgradeClickXpCount;
            progress.LvlForUpgradeClickPrice = _staticDataProvider.DefaultPlayerSettings.LvlForUpgradeClickPrice;
            progress.PriceForUpgradeMoneyClick = _staticDataProvider.DefaultPlayerSettings.PriceForUpgradeMoneyClick;
            progress.PriceForUpgradeXpClick = _staticDataProvider.DefaultPlayerSettings.PriceForUpgradeXpClick;
            progress.LvlForUpgradeClickXpPrice = _staticDataProvider.DefaultPlayerSettings.LvlForUpgradeClickXpPrice;
            progress.AddLvlCount = _staticDataProvider.DefaultPlayerSettings.AddLvlCount;
        }
    }
}