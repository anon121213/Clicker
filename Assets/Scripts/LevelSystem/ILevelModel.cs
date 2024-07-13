﻿using System;

namespace LevelSystem
{
    public interface ILevelModel
    {
        event Action OnValueChanged;
        int CurrentLvL { get; }
        int ClicksForNewLvL { get; }
        int CurrentXp { get; }
        void AddLvL(int value);
        void AddXp(int value);
        void AddClicksForNewLvl(int value);
        bool TryUpgradeLevel(int currentXp, int clickPrice, int clicksForNewLvl, int ClickXpPrice);
        void RemoveCurrentClicks();
    }
}