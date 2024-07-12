using ClickSystem;
using UpgradeSystem;

namespace LevelSystem
{
    public class LevelPresenter
    {
        private LevelView _levelView;
        private LevelModel _levelModel;
        private UpgradesMoneyModel _upgradesMoneyModel;
        private readonly LevelUpgradesModel _levelUpgradesModel;
        private readonly ClickerPresenter _clickerPresenter;

        public LevelPresenter(LevelView levelView, LevelModel levelModel, UpgradesMoneyModel upgradesMoneyModel, LevelUpgradesModel levelUpgradesModel, ClickerPresenter clickerPresenter)
        {
            _levelView = levelView;
            _levelModel = levelModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _levelUpgradesModel = levelUpgradesModel;
            _clickerPresenter = clickerPresenter;

            Start();
        }

        private void Start()
        {
            _levelModel.OnValueChanged += UpdateUi;
            _clickerPresenter.ClickButton.onClick.AddListener(OnClick);

            UpdateUi();
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
