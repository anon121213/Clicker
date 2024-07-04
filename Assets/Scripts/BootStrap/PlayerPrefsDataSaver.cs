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
        playerData.UpgradeClickXpCount = PlayerPrefs.GetInt("upgradeXpCount");
        playerData.UpgradeClickPriceCount = PlayerPrefs.GetInt("upgradeClickPriceCount");
        playerData.PriceUpgradeMoneyClickPrice = PlayerPrefs.GetInt("priceUpgradeMoneyClickClickPrice");
        playerData.PriceUpgradeXpClickPrice = PlayerPrefs.GetInt("priceUpgradeXpClickClickPrice");
        return playerData;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("clickPrice", PlayerData.Instance.ClickPrice);
        PlayerPrefs.SetInt("clickXpPrice", PlayerData.Instance.ClickXpPrice);
        PlayerPrefs.SetInt("lvlForUpgradeClickPrice", PlayerData.Instance.LvlForUpgradeClickPrice);
        PlayerPrefs.SetInt("lvlForUpgradeClickXpPrice", PlayerData.Instance.LvlForUpgradeClickXpPrice);
        PlayerPrefs.SetInt("money", PlayerData.Instance.Money);
        PlayerPrefs.SetInt("currentLvl", PlayerData.Instance.CurrentLvl);
        PlayerPrefs.SetInt("clicksForNewLvl", PlayerData.Instance.ClicksForNewLvl);
        PlayerPrefs.SetInt("currentClicks", PlayerData.Instance.CurrentClicks);
        PlayerPrefs.SetInt("upgradeXpCount", PlayerData.Instance.UpgradeClickXpCount);
        PlayerPrefs.SetInt("upgradeClickPriceCount", PlayerData.Instance.UpgradeClickPriceCount);
        PlayerPrefs.SetInt("priceUpgradeMoneyClickClickPrice", PlayerData.Instance.PriceUpgradeMoneyClickPrice);
        PlayerPrefs.SetInt("priceUpgradeXpClickClickPrice", PlayerData.Instance.PriceUpgradeXpClickPrice);
        PlayerPrefs.Save();
    }
}