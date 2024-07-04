using UnityEngine;
using TMPro;

public class UpgradesView: MonoBehaviour, IUpgradesView
{
    [SerializeField] private TextMeshProUGUI _clickPriceText;
    [SerializeField] private TextMeshProUGUI _clickXpPriceText;
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

    public void UpdateUpgradePrice(int count)
    {
        _priceClickUpgradePriceText.text = $"Upgrade price: {count}";
        _priceClickXpUpgradePriceText.text = $"Upgrade price: {count}";
    }
}
