namespace UpgradeSystem
{
    public interface IUpgradesView
    {
        void UpdateClickPrice(int count);
        void UpdateClickXpPrice(int count);
        void UpdateUpgradeClickMoney(int ClickUpgradeBuff, int ClickXpUpgradeBuff);
        void UpdateUpgradeClickXp(int ClickUpgradePrice, int ClickXpUpgradePrice);
        void UpdateNeedLvlForUpgradeMoneyClick(int count);
        void UpdateNeedLvlForUpgradeXpClick(int count);
    }
}
