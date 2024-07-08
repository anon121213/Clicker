using System;
using UnityEngine;

namespace UpgradeSystem
{
    public class UpgradesModel: MonoBehaviour
    {
        private int _clickPrice = 1;
        private int _clickXpPrice = 1;
        private int _lvlForUpgradeClickPrice = 1;
        private int _lvlForUpgradeClickXpPrice = 1;
        private int _upgradeClickXpCount = 1;
        private int _upgradeClickPrice = 1;
        private int _priceUpgradeMoneyClickClickPrice = 30;
        private int _priceUpgradeXpClickClickPrice = 30;
    
        public int UpgradeClickPrice
        {
            get => _upgradeClickPrice;
            set => _upgradeClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
        }
    
        public int UpgradeClickXpPrice
        {
            get => _upgradeClickXpCount;
            set => _upgradeClickXpCount = Mathf.Clamp(value, 0, Int32.MaxValue);
        }
    
        public int UpgradePriceForUpgradeMoneyClick
        {
            get => _priceUpgradeMoneyClickClickPrice;
            set => _priceUpgradeMoneyClickClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
        }
    
        public int UpgradePriceForUpgradeXpClick
        {
            get => _priceUpgradeXpClickClickPrice;
            set => _priceUpgradeXpClickClickPrice = Mathf.Clamp(value, 0, Int32.MaxValue);
        }
    
        public int GetLvlForUpgradeClickPrice()
        {
            return _lvlForUpgradeClickPrice;
        }
    
        public int GetLvlForUpgradeXpClickPrice()
        {
            return _lvlForUpgradeClickXpPrice;
        }
    
        public int GetClickPrice()
        {
            return _clickPrice;
        }

        public int GetClickXpPrice()
        {
            return _clickXpPrice;
        }
    
        public void IncrementClickPrice(int clickPriceIncrementCount)
        {
            _clickPrice += clickPriceIncrementCount;
        }

        public void IncrementClickXpPrice(int clickXpPriceIncrementCount)
        {
            _clickXpPrice += clickXpPriceIncrementCount;
        }

        public void IncrementLvlForUpgradeClick(int count)
        {
            _lvlForUpgradeClickPrice += count;
        }
    
        public void IncrementLvlForUpgradeXpClick(int count)
        {
            _lvlForUpgradeClickXpPrice += count;
        }
    }
}
