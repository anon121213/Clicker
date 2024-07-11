using System;
using UnityEngine;

namespace ClickSystem
{
    public class ClickerModel
    {
        private int _money;

        public event Action OnValueChanged;
        
        public int Money =>
            _money;

        public void AddMoney(int count)
        {
            _money += count;
            OnValueChanged?.Invoke();
        }

        public void RemoveMoney(int cout)
        {
            _money = Mathf.Clamp(_money - cout, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }
    }
}
