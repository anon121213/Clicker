using System;
using UnityEngine;

namespace UpgradeSystem
{
    public class UpgradesModel
    {
        private int _clickPrice;
        private int _clickXpPrice;
        private int _upgradeClickXpCount;
        private int _upgradeClickPrice;
        private int _priceUpgradeMoneyClickClickPrice;
        private int _priceUpgradeXpClickClickPrice;

        public event Action OnValueChanged;
        
        public int ClickPrice =>
            _clickPrice;

        public void AddClickPrice(int count)
        {
            _clickPrice = Mathf.Clamp(_clickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int ClickXpPrice =>
            _clickXpPrice;

        public void AddClickXpPrice(int count)
        {
            _clickXpPrice = Mathf.Clamp(_clickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int UpgradeClickPrice =>
            _upgradeClickPrice;

        public void AddUpgradeClickPrice(int count)
        {
            _upgradeClickPrice = Mathf.Clamp(_upgradeClickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int UpgradeClickXpPrice =>
            _upgradeClickXpCount;

        public void AddUpgradeClickXpPrice(int count)
        {
            _upgradeClickXpCount = Mathf.Clamp(_upgradeClickXpCount + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int UpgradePriceForUpgradeMoneyClick =>
            _priceUpgradeMoneyClickClickPrice;

        public void AddUpgradePriceForUpgradeMoneyClick(int count)
        {
            _priceUpgradeMoneyClickClickPrice =
                Mathf.Clamp(_priceUpgradeMoneyClickClickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int UpgradePriceForUpgradeXpClick =>
            _priceUpgradeXpClickClickPrice;

        public void AddUpgradePriceForUpgradeXpClick(int count)
        {
            _priceUpgradeXpClickClickPrice = Mathf.Clamp(_priceUpgradeXpClickClickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }
    }
}
