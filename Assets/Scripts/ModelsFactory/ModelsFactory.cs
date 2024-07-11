using ClickSystem;
using LevelSystem;
using PopUp.Factory;
using UpgradeSystem;
using VContainer;

namespace ModelsFactory
{
    public class ModelsFactory : IModelsFactory
    {
        [Inject] private ClickerView _clickerView;
        [Inject] private UpgradesModel _upgradesModel;
        [Inject] private IPopUpFactory _popUpFactory;
        [Inject] private LevelView _levelView;
        [Inject] private LevelModel _levelModel;
        
        public ClickerModel CreateClickModel()
        {
            return new ClickerModel(_clickerView, _upgradesModel, _popUpFactory);
        }

        public LevelModel CreateLevelModel()
        {
            return new LevelModel(_levelView, _upgradesModel);
        }
    }

    public interface IModelsFactory
    {
        ClickerModel CreateClickModel();
        LevelModel CreateLevelModel();
    }
}