using System;

namespace UpgradeSystem
{
    public interface IUpgradesMoneyModel
    {
        event Action OnValueChanged;
        int ClickPrice { get; }
        int LvlForUpgradeClickPrice { get; }
        int UpgradeClickPrice { get; }
        int PriceForUpgradeMoneyClick { get; }
        void AddClickPrice(int count);
        bool TryAddLvlForUpgradeClickPrice(int lvlForUpgradeClickPrice, int currentLevel, int count);
        void AddLvlForUpgradeClickPrice(int count);
        void AddUpgradeClickPrice(int count);
        void AddUpgradePriceForUpgradeMoneyClick(int count);
    }
}