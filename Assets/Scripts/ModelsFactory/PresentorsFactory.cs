using ClickSystem;
using LevelSystem;
using PopUp.Factory;
using UpgradeSystem;
using VContainer;

namespace ModelsFactory
{
    public class PresentorsFactory : IPresentorsFactory
    {
        [Inject] private ClickerView _clickerView;
        [Inject] private ClickerModel _clickerModel;
        [Inject] private UpgradesMoneyModel _upgradesMoneyModel;
        [Inject] private IPopUpFactory _popUpFactory;
        [Inject] private LevelView _levelView;
        [Inject] private LevelModel _levelModel;
        [Inject] private UpgradesView _upgradesView;
        [Inject] private LevelUpgradesModel _levelUpgradesModel;

        private ClickerPresenter _clickerPresenter;
        
        public ClickerPresenter CreateClickPresentor()
        {
            return _clickerPresenter = new ClickerPresenter(_clickerModel, _clickerView, _upgradesMoneyModel, _popUpFactory);
        }

        public LevelPresenter CreateLevelPresentor()
        {
            return new LevelPresenter(_levelView, _levelModel, _upgradesMoneyModel, _levelUpgradesModel, _clickerPresenter);
        }

        public UpgradesPresenter CreateUpgradesPresentor()
        {
            return new UpgradesPresenter(_upgradesView, _clickerView, _upgradesMoneyModel,
                _clickerModel, _levelUpgradesModel, _levelModel);
        }
    }

    public interface IPresentorsFactory
    {
        ClickerPresenter CreateClickPresentor();
        LevelPresenter CreateLevelPresentor();

        UpgradesPresenter CreateUpgradesPresentor();
    }
}