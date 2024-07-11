using UpgradeSystem;

namespace LevelSystem
{
    public class LevelPresenter
    {
        private LevelView _levelView;
        private LevelModel _levelModel;
        private UpgradesMoneyModel _upgradesMoneyModel;
        private readonly LevelUpgradesModel _levelUpgradesModel;

        public LevelPresenter(LevelView levelView, LevelModel levelModel, UpgradesMoneyModel upgradesMoneyModel, LevelUpgradesModel levelUpgradesModel)
        {
            _levelView = levelView;
            _levelModel = levelModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _levelUpgradesModel = levelUpgradesModel;

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
            if (_levelModel.CurrentXp + _upgradesMoneyModel.ClickPrice < _levelModel.ClicksForNewLvL)
            {
                _levelModel.AddXp(_levelUpgradesModel.ClickXpPrice);
            }
            else
            {
                _levelModel.AddLvL(_upgradesMoneyModel.ClickPrice);
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
