using System;

namespace UpgradeSystem.Models
{
    public interface ILevelUpgradesModel
    {
        event Action OnValueChanged;
        int ClickXpPrice { get; }
        int UpgradeClickXpPrice { get; }
        int PriceForUpgradeXpClick { get; }
        int LvlForUpgradeClickXpPrice { get; }
        void AddClickXpPrice(int count);
        void AddUpgradeClickXpPrice(int count);
        void AddPriceForUpgradeXpClick(int count);
        bool TryAddLvlForUpgradeClickPrice(int LvlForUpgradeClickXpPrice, int currentLevel, int count);
        void AddLvlForUpgradeClickXpPrice(int count);
    }
}