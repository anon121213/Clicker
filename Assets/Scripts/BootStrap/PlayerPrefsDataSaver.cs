using UnityEngine;

public class PlayerPrefsDataSaver : IDataSaver
{
    public PlayerData Load()
    {
        var playerData = new PlayerData();
        playerData.ClickPrice = PlayerPrefs.GetInt("clickPrice");
        playerData.ClickXpPrice = PlayerPrefs.GetInt("clickXpPrice");
        playerData.LvlForUpgradeClickPrice = PlayerPrefs.GetInt("lvlForUpgradeClickPrice");
        playerData.LvlForUpgradeClickXpPrice = PlayerPrefs.GetInt("lvlForUpgradeClickXpPrice");
        playerData.Money = PlayerPrefs.GetInt("money");
        playerData.CurrentLvl = PlayerPrefs.GetInt("currentLvl");
        playerData.ClicksForNewLvl = PlayerPrefs.GetInt("clicksForNewLvl");
        playerData.CurrentClicks = PlayerPrefs.GetInt("currentClicks");
        playerData.UpgradeXpCount = PlayerPrefs.GetInt("upgradeXpCount");
        playerData.UpgradeClickPriceCount = PlayerPrefs.GetInt("upgradeClickPriceCount");
        playerData.PriceUpgradeMoneyClickClickPrice = PlayerPrefs.GetInt("priceUpgradeMoneyClickClickPrice");
        playerData.PriceUpgradeXpClickClickPrice = PlayerPrefs.GetInt("priceUpgradeXpClickClickPrice");
        return playerData;
    }

    public void Save(PlayerData playerData)
    {
        PlayerPrefs.SetInt("clickPrice", playerData.ClickPrice);
        PlayerPrefs.SetInt("clickXpPrice", playerData.ClickXpPrice);
        PlayerPrefs.SetInt("lvlForUpgradeClickPrice", playerData.LvlForUpgradeClickPrice);
        PlayerPrefs.SetInt("lvlForUpgradeClickXpPrice", playerData.LvlForUpgradeClickXpPrice);
        PlayerPrefs.SetInt("money", playerData.Money);
        PlayerPrefs.SetInt("currentLvl", playerData.CurrentLvl);
        PlayerPrefs.SetInt("clicksForNewLvl", playerData.ClicksForNewLvl);
        PlayerPrefs.SetInt("currentClicks", playerData.CurrentClicks);
        PlayerPrefs.SetInt("upgradeXpCount", playerData.UpgradeXpCount);
        PlayerPrefs.SetInt("upgradeClickPriceCount", playerData.UpgradeClickPriceCount);
        PlayerPrefs.SetInt("priceUpgradeMoneyClickClickPrice", playerData.PriceUpgradeMoneyClickClickPrice);
        PlayerPrefs.SetInt("priceUpgradeXpClickClickPrice", playerData.PriceUpgradeXpClickClickPrice);
        PlayerPrefs.Save();
    }
}