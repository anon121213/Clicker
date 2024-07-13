using System;

namespace ClickSystem
{
    public interface IClickerModel
    {
        event Action OnValueChanged;
        int Money { get; }
        void AddMoney(int count);
        bool TryRemoveMoney(int cout);
        void RemoveMoney(int cout);
    }
}