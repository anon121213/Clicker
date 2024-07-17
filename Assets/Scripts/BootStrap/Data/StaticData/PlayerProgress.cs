﻿using System;

namespace BootStrap.Data.StaticData
{
    [Serializable]
    public class PlayerProgress
    {
        public int Money = 0;
        public int CurrentLvl = 1;
        public int ClicksForNewLvl = 100;
        public int CurrentXp = 0;
        public int ClickPrice = 1;
        public int ClickXpPrice = 1;
        public int LvlForUpgradeClickPrice = 1;
        public int LvlForUpgradeClickXpPrice = 1;
        public int UpgradeClickXpCount = 1;
        public int UpgradeClickPrice = 1;
        public int PriceForUpgradeMoneyClick = 30;
        public int PriceForUpgradeXpClick = 30;
        public int AddLvlCount = 1;
    }
}