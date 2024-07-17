using UnityEngine;

namespace BootStrap.Data.StaticData
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObject/PlayerSettings")]
    public class DefaultPlayerSettings : ScriptableObject
    {
        [SerializeField, Range(0, 10000)] private int _money = 0;
        [SerializeField, Range(0, 10000)] private int _currentLvl = 1;
        [SerializeField, Range(0, 10000)] private int _clicksForNewLvl = 100;
        [SerializeField, Range(0, 10000)] private int _currentXp = 0;
        [SerializeField, Range(0, 10000)] private int _clickPrice = 1;
        [SerializeField, Range(0, 10000)] private int _clickXpPrice = 1;
        [SerializeField, Range(0, 10000)] private int _lvlForUpgradeClickPrice = 1;
        [SerializeField, Range(0, 10000)] private int _lvlForUpgradeClickXpPrice = 1;
        [SerializeField, Range(0, 10000)] private int _upgradeClickXpCount = 1;
        [SerializeField, Range(0, 10000)] private int _upgradeClickPrice = 1;
        [SerializeField, Range(0, 10000)] private int _priceForUpgradeMoneyClick = 30;
        [SerializeField, Range(0, 10000)] private int _priceForUpgradeXpClick = 30;
        [SerializeField, Range(0, 10000)] private int _addLvlCount = 1;

        public int Money => 
            _money;
        public int CurrentLvl => 
            _currentLvl;
        public int ClicksForNewLvl =>
            _clicksForNewLvl;
        public int CurrentXp =>
            _currentXp;
        public int ClickPrice => 
            _clickPrice;
        public int ClickXpPrice =>
            _clickXpPrice;
        public int LvlForUpgradeClickPrice =>
            _lvlForUpgradeClickPrice;
        public int LvlForUpgradeClickXpPrice =>
            _lvlForUpgradeClickXpPrice;
        public int UpgradeClickXpCount =>
            _upgradeClickXpCount;
        public int UpgradeClickPrice =>
            _upgradeClickPrice;
        public int PriceForUpgradeMoneyClick =>
            _priceForUpgradeMoneyClick;
        public int PriceForUpgradeXpClick =>
            _priceForUpgradeXpClick;

        public int AddLvlCount =>
            _addLvlCount;
    }   
}