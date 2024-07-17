using System;

namespace LevelSystem
{
    public interface ILevelModel
    {
        event Action OnValueChanged;
        int CurrentLvL { get; }
        int ClicksForNewLvL { get; }
        int CurrentXp { get; }
        public int AddLvlCount { get; }
        void AddLvL(int value);
        void AddXp(int value);
        void AddClicksForNewLvl(int value);
        void TryUpgradeLevel(int currentXp, int clickPrice, int clicksForNewLvl, int clickXpPrice, int addLvl);
        void ChangeLvlCount(int value);
        void RemoveCurrentClicks();
    }
}