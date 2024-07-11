using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UpgradeSystem
{
    public class UpgradesView: MonoBehaviour
    {
        public Button _upgradeClickPriceButton;
        public Button _upgradeXpPriceButton;
        
        [SerializeField] private TextMeshProUGUI _clickPriceText;
        [SerializeField] private TextMeshProUGUI _clickXpPriceText;
        [SerializeField] private TextMeshProUGUI _priceClickUpgradeBuffText;
        [SerializeField] private TextMeshProUGUI _priceClickXpUpgradeBuffText;
        [SerializeField] private TextMeshProUGUI _priceClickUpgradePriceText;
        [SerializeField] private TextMeshProUGUI _priceClickXpUpgradePriceText;
        [SerializeField] private TextMeshProUGUI _needLvlForUpgradeMoneyClick;
        [SerializeField] private TextMeshProUGUI _needLvlForUpgradeXpClick;
    
        public void UpdateClickPrice(int count) =>
            _clickPriceText.text = $"Click price: {count}";

        public void UpdateClickXpPrice(int count) =>
            _clickXpPriceText.text = $"Click xp price: {count}";

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

        public void UpdateNeedLvlForUpgradeMoneyClick(int count) =>
            _needLvlForUpgradeMoneyClick.text = $"lvl: {count}";

        public void UpdateNeedLvlForUpgradeXpClick(int count) =>
            _needLvlForUpgradeXpClick.text = $"lvl: {count}";
    }
}
