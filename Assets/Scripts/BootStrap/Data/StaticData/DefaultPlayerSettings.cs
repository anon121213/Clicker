using UnityEngine;

namespace BootStrap.Data.StaticData
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObject/PlayerSettings")]
    public class DefaultPlayerSettings : ScriptableObject
    {
        [SerializeField, Min(0)] private int _money = 0;
        [SerializeField, Min(0)] private int _currentLvl = 1;
        [SerializeField, Min(0)] private int _clicksForNewLvl = 100;
        [SerializeField, Min(0)] private int _currentXp = 0;
        [SerializeField, Min(0)] private int _clickPrice = 1;
        [SerializeField, Min(0)] private int _clickXpPrice = 1;
        [SerializeField, Min(0)] private int _lvlForUpgradeClickPrice = 1;
        [SerializeField, Min(0)] private int _lvlForUpgradeClickXpPrice = 1;
        [SerializeField, Min(0)] private int _upgradeClickXpCount = 1;
        [SerializeField, Min(0)] private int _upgradeClickPrice = 1;
        [SerializeField, Min(0)] private int _priceForUpgradeMoneyClick = 30;
        [SerializeField, Min(0)] private int _priceForUpgradeXpClick = 30;

        public int Money { get => _money; }
        public int CurrentLvl { get => _currentLvl; }
        public int ClicksForNewLvl { get => _clicksForNewLvl; }
        public int CurrentXp { get => _currentXp; }
        public int ClickPrice { get => _clickPrice; }
        public int ClickXpPrice { get => _clickXpPrice; }
        public int LvlForUpgradeClickPrice { get => _lvlForUpgradeClickPrice; }
        public int LvlForUpgradeClickXpPrice { get => _lvlForUpgradeClickXpPrice; }
        public int UpgradeClickXpCount { get => _upgradeClickXpCount; }
        public int UpgradeClickPrice { get => _upgradeClickPrice; }
        public int PriceForUpgradeMoneyClick { get => _priceForUpgradeMoneyClick; }
        public int PriceForUpgradeXpClick { get => _priceForUpgradeXpClick; }
    }   
}