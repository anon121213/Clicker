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
            _levelModel.OnValueChanged += UpdateUi;
            _levelView._clickButton.onClick.AddListener(OnClick);
                
            _levelView.UpdateLevel(_levelModel.CurrentXp, _levelModel.ClicksForNewLvL);
            _levelView.UpdateClicksForNewLvlText(_levelModel.ClicksForNewLvL,_levelModel.CurrentLvL);
        }

        private void OnClick()
        {
            if (_levelModel.CurrentXp + _upgradesModel.ClickPrice < _levelModel.ClicksForNewLvL)
            {
                _levelModel.AddXp(_upgradesModel.ClickXpPrice);
            }
            else
            {
                _levelModel.AddLvL(_upgradesModel.ClickPrice);
                _levelModel.AddClicksForNewLvl(_levelModel.ClicksForNewLvL);
                _levelModel.RemoveCurrentClicks();
            }
        }

        private void UpdateUi()
        {
            _levelView.UpdateLevel(_levelModel.CurrentXp, _levelModel.ClicksForNewLvL);
            _levelView.UpdateClicksForNewLvlText(_levelModel.ClicksForNewLvL, _levelModel.CurrentLvL);
        }

        public void Disable()
        {
            _levelModel.OnValueChanged -= UpdateUi;
        }
    }
}
