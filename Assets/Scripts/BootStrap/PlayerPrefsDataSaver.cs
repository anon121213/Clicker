using UnityEngine;

public class PlayerPrefsDataSaver : IDataSaver
{
    public PlayerData Load()
    {
        var playerData = new PlayerData();
        var lickPrice = PlayerPrefs.GetInt("clickPrice");
        var clickXpPrice = PlayerPrefs.GetInt("clickXpPrice");
        var lvlForUpgradeClickPrice = PlayerPrefs.GetInt("lvlForUpgradeClickPrice");
        var lvlForUpgradeClickXpPrice = PlayerPrefs.GetInt("lvlForUpgradeClickXpPrice");
        var money = PlayerPrefs.GetInt("money");
        var currentLvl = PlayerPrefs.GetInt("currentLvl");
        var clicksForNewLvl = PlayerPrefs.GetInt("clicksForNewLvl");
        var currentClicks = PlayerPrefs.GetInt("currentClicks");
        var upgradeXpCount = PlayerPrefs.GetInt("upgradeXpCount");
        var upgradeClickPriceCount = PlayerPrefs.GetInt("upgradeClickPriceCount");
        var priceUpgradeMoneyClickClickPrice = PlayerPrefs.GetInt("priceUpgradeMoneyClickClickPrice");
        var priceUpgradeXpClickClickPrice = PlayerPrefs.GetInt("priceUpgradeXpClickClickPrice");
        return playerData;
    }

    public void Save(PlayerData playerData)
    {
        PlayerPrefs.SetInt("clickPrice", playerData.ClickPrice);
        PlayerPrefs.SetInt("ClickXpPrice", playerData.ClickXpPrice);
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