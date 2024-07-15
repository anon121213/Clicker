﻿using System;
using UnityEngine;

namespace UpgradeSystem.Models
{
    public class UpgradesMoneyModel : IUpgradesMoneyModel
    {
        private int _clickPrice;
        private int _lvlForUpgradeClickPrice;
        private int _upgradeClickPrice;
        private int _pricePriceForUpgradeMoneyClickClickPrice;

        public event Action OnValueChanged;
        
        public int ClickPrice =>
            _clickPrice;

        public void AddClickPrice(int count)
        {
            _clickPrice = Mathf.Clamp(_clickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int LvlForUpgradeClickPrice =>
            _lvlForUpgradeClickPrice;

        public bool TryAddLvlForUpgradeClickPrice(int lvlForUpgradeClickPrice, int currentLevel, int count)
        {
            if (lvlForUpgradeClickPrice <= currentLevel)
            {
                _lvlForUpgradeClickPrice = Mathf.Clamp(_lvlForUpgradeClickPrice + count, 0, Int32.MaxValue);
                OnValueChanged?.Invoke();

                return true;
            }

            return false;
        }
        
        public void AddLvlForUpgradeClickPrice(int count)
        {
            _lvlForUpgradeClickPrice = Mathf.Clamp(_lvlForUpgradeClickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int UpgradeClickPrice =>
            _upgradeClickPrice;

        public void AddUpgradeClickPrice(int count)
        {
            _upgradeClickPrice = Mathf.Clamp(_upgradeClickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }

        public int PriceForUpgradeMoneyClick =>
            _pricePriceForUpgradeMoneyClickClickPrice;

        public void AddUpgradePriceForUpgradeMoneyClick(int count)
        {
            _pricePriceForUpgradeMoneyClickClickPrice = Mathf.Clamp(_pricePriceForUpgradeMoneyClickClickPrice + count, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }
    }
}