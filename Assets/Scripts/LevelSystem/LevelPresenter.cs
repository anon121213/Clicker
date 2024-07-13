using BootStrap.Data;
using ClickSystem;
using UnityEngine;
using UpgradeSystem;

namespace LevelSystem
{
    public class LevelPresenter: IPresentor
    {
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;
        private readonly ILevelUpgradesModel _levelUpgradesModel;
        private readonly ILevelModel _levelModel;
        
        private readonly LevelView _levelView;
        
        private readonly ClickerPresenter _clickerPresenter;

        public LevelPresenter(LevelView levelView, ILevelModel levelModel, IUpgradesMoneyModel upgradesMoneyModel, ILevelUpgradesModel levelUpgradesModel, ClickerPresenter clickerPresenter)
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
            _levelModel.TryUpgradeLevel(_levelModel.CurrentXp, _upgradesMoneyModel.ClickPrice,
                _levelModel.ClicksForNewLvL, _levelUpgradesModel.ClickXpPrice);
        }

        private void UpdateUi()
        {
            _levelView.UpdateLevel(_levelModel.CurrentXp, _levelModel.ClicksForNewLvL);
            _levelView.UpdateClicksForNewLvlText(_levelModel.ClicksForNewLvL, _levelModel.CurrentLvL);
        }

        public void Disable()
        {
            Debug.Log("a");
            _levelModel.OnValueChanged -= UpdateUi;
        }
    }
}
