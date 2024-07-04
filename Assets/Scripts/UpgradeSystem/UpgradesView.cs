using UnityEngine;
using TMPro;

public class UpgradesView: MonoBehaviour, IUpgradesView
{
    [SerializeField] private TextMeshProUGUI _clickPriceText;
    [SerializeField] private TextMeshProUGUI _clickXpPriceText;
    [SerializeField] private TextMeshProUGUI _priceClickUpgradeBuffText;
    [SerializeField] private TextMeshProUGUI _priceClickXpUpgradeBuffText;
    [SerializeField] private TextMeshProUGUI _priceClickUpgradePriceText;
    [SerializeField] private TextMeshProUGUI _priceClickXpUpgradePriceText;
    
    public void UpdateClickPrice(int count)
    {
        _clickPriceText.text = $"Click price: {count}";
    }

    public void UpdateClickXpPrice(int count)
    {
        _clickXpPriceText.text = $"Click xp price: {count}";
    }

    public void UpdateUpgradeClickMoney(int price, int buff)
    {
        _priceClickUpgradeBuffText.text = $"Click buff: +{buff}";
        _priceClickUpgradePriceText.text = $"price: {price}";
    }

    public void UpdateUpgradeClickXp(int price, int buff)
    {
        _priceClickXpUpgradeBuffText.text = $"Click xp buff: +{buff}";
        _priceClickXpUpgradePriceText.text = $"price: {price}";
    }
}
