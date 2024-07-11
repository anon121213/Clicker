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
        [Inject] private UpgradesModel _upgradesModel;
        [Inject] private IPopUpFactory _popUpFactory;
        [Inject] private LevelView _levelView;
        [Inject] private LevelModel _levelModel;
        [Inject] private UpgradesView _upgradesView;
        [Inject] private LevelUpgradesModel _levelUpgradesModel;
        
        public ClickerPresenter CreateClickPresentor()
        {
            return new ClickerPresenter(_clickerModel, _clickerView, _upgradesModel, _popUpFactory);
        }

        public LevelPresenter CreateLevelPresentor()
        {
            return new LevelPresenter(_levelView, _levelModel, _upgradesModel);
        }

        public UpgradesPresenter CreateUpgradesPresentor()
        {
            return new UpgradesPresenter(_upgradesView, _clickerView, _upgradesModel,
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