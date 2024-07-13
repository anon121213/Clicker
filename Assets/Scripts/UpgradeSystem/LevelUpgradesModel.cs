using System;
using UnityEngine;

namespace UpgradeSystem
{
    public class LevelUpgradesModel : ILevelUpgradesModel
    {
        private int _clickXpPrice;
        private int _upgradeClickXpPrice;
        private int _priceForUpgradeXpClick;
        private int _lvlForUpgradeClickXpPrice;
        
        public event Action OnValueChanged;
        
        public int ClickXpPrice =>
            _clickXpPrice;

        public void AddClickXpPrice(int count)
        {
            _clickXpPrice = Mathf.Clamp(_clickXpPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int UpgradeClickXpPrice =>
            _upgradeClickXpPrice;

        public void AddUpgradeClickXpPrice(int count)
        {
            _upgradeClickXpPrice = Mathf.Clamp(_upgradeClickXpPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int PriceForUpgradeXpClick =>
            _priceForUpgradeXpClick;

        public void AddPriceForUpgradeXpClick(int count)
        { 
            _priceForUpgradeXpClick = Mathf.Clamp(_priceForUpgradeXpClick + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int LvlForUpgradeClickXpPrice =>
            _lvlForUpgradeClickXpPrice;
        
        public bool TryAddLvlForUpgradeClickPrice(int LvlForUpgradeClickXpPrice, int currentLevel, int count)
        {
            if (LvlForUpgradeClickXpPrice <= currentLevel)
            {
                _lvlForUpgradeClickXpPrice = Mathf.Clamp(_lvlForUpgradeClickXpPrice + count, 0, Int32.MaxValue);
                OnValueChanged?.Invoke();

                return true;
            }

            return false;
        }

        public void AddLvlForUpgradeClickXpPrice(int count)
        {
            _lvlForUpgradeClickXpPrice = Mathf.Clamp(_lvlForUpgradeClickXpPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }
    }
}