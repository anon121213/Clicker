using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelSystem
{
    public class LevelView: MonoBehaviour
    {
        [SerializeField] private Image _lvlBar;
        [SerializeField] private TextMeshProUGUI _clicksForNewLvlText;
        [SerializeField] private TextMeshProUGUI _clicksCountText;
        [SerializeField] private TextMeshProUGUI _level;
    
        public void UpdateLevel(int currentClicks, int clicksForNewLvl)
        {
            _lvlBar.fillAmount = (float)currentClicks / clicksForNewLvl;
            _clicksCountText.text = $"Current: {currentClicks}";
        }

        public void UpdateClicksForNewLvlText(int clicksForNewLvl, int newLevel)
        {
            _level.text = $"lvl {newLevel}";
            _clicksForNewLvlText.text = $"Need to up: {clicksForNewLvl}";
        }
    }
}
