using System;
using ClickSystem;
using UpgradeSystem.Models;

namespace LevelSystem
{
    public class LevelPresenter: IDisposable
    {
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;
        private readonly ILevelUpgradesModel _levelUpgradesModel;
        private readonly ILevelModel _levelModel;
        
        private LevelView _levelView;
        
        private readonly ClickerPresenter _clickerPresenter;

        public LevelPresenter(ILevelModel levelModel, IUpgradesMoneyModel upgradesMoneyModel, ILevelUpgradesModel levelUpgradesModel, ClickerPresenter clickerPresenter)
        {
            _levelModel = levelModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _levelUpgradesModel = levelUpgradesModel;
            _clickerPresenter = clickerPresenter;
        }

        public void Constructor(LevelView levelView) =>
            _levelView = levelView;

        public void Start()
        {
            _levelModel.OnValueChanged += UpdateUi;
            _clickerPresenter.ClickButton.onClick.AddListener(OnClick);

            UpdateUi();
        }

        private void OnClick()
        {
            _levelModel.TryUpgradeLevel(_levelModel.CurrentXp, _upgradesMoneyModel.ClickPrice,
                _levelModel.ClicksForNewLvL, _levelUpgradesModel.ClickXpPrice, _levelModel.AddLvlCount);
        }

        private void UpdateUi()
        {
            _levelView.UpdateLevel(_levelModel.CurrentXp, _levelModel.ClicksForNewLvL);
            _levelView.UpdateClicksForNewLvlText(_levelModel.ClicksForNewLvL, _levelModel.CurrentLvL);
        }

        public void Dispose()
        {
            _clickerPresenter.ClickButton.onClick.RemoveAllListeners();
            _levelModel.OnValueChanged -= UpdateUi;
        }
    }
}
