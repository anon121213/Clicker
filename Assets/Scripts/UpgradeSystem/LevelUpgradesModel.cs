using System;
using UnityEngine;

namespace UpgradeSystem
{
    public class LevelUpgradesModel
    {
        private int _lvlForUpgradeClickPrice;
        private int _lvlForUpgradeClickXpPrice;
        
        public event Action OnValueChanged;
        
        public int LvlForUpgradeClickPrice =>
            _lvlForUpgradeClickPrice;

        public void AddLvlForUpgradeClickPrice(int count)
        {
            _lvlForUpgradeClickPrice = Mathf.Clamp(_lvlForUpgradeClickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int LvlForUpgradeClickXpPrice =>
            _lvlForUpgradeClickXpPrice;

        public void AddLvlForUpgradeClickXpPrice(int count)
        {
            _lvlForUpgradeClickXpPrice = Mathf.Clamp(_lvlForUpgradeClickXpPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }
    }
}