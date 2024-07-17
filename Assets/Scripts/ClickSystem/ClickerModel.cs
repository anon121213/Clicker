using System;
using UnityEngine;

namespace ClickSystem
{
    public class ClickerModel : IClickerModel
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

        public bool TryRemoveMoney(int cout)
        {
            if (cout > _money)
                return false;
            
            _money = Mathf.Clamp(_money - cout, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
            
            return true;
        }
        
        public void RemoveMoney(int cout)
        {
            _money = Mathf.Clamp(_money - cout, 0, Int32.MaxValue);
            OnValueChanged?.Invoke();
        }
    }
}
