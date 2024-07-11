using UnityEngine;
using UpgradeSystem;

namespace LevelSystem
{
    public class LevelPresenter
    {
        private LevelView _levelView;
        private LevelModel _levelModel;
        private UpgradesModel _upgradesModel;

        public LevelPresenter(LevelView levelView, LevelModel levelModel, UpgradesModel upgradesModel)
        {
            _levelView = levelView;
            _levelModel = levelModel;
            _upgradesModel = upgradesModel;
            Start();
        }

        private void Start()
        {
            _levelView._clickButton.onClick.AddListener(OnClick);
            _levelView.UpdateLevel(_levelModel.GetCurrentClicks(), _levelModel.GetClicksForNewLvL());
            _levelView.UpdateClicksForNewLvlText(_levelModel.GetClicksForNewLvL(),_levelModel.GetCurrentLvL());
        }

        private void OnClick()
        {
            if (_levelModel.GetCurrentClicks() + _upgradesModel.GetClickPrice() < _levelModel.GetClicksForNewLvL())
            {
                _levelModel.IncrementClicks(_upgradesModel.GetClickXpPrice());
                _levelView.UpdateLevel(_levelModel.GetCurrentClicks(), _levelModel.GetClicksForNewLvL());
            }
            else
            {
                _levelModel.IncrementLvL(1);
                _levelModel.IncrementClicksForNewLvl();
                _levelModel.DecrimentCuddentClicks();
                _levelView.UpdateLevel(_upgradesModel.GetClickXpPrice(), _levelModel.GetClicksForNewLvL());
                _levelView.UpdateClicksForNewLvlText(_levelModel.GetClicksForNewLvL(), _levelModel.GetCurrentLvL());
            }
        }
    }
}
