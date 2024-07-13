using System;
using BootStrap.AssetsLoader;
using BootStrap.AssetsLoader.Services;
using BootStrap.Data;
using BootStrap.Data.DataService;
using ClickSystem;
using Cysharp.Threading.Tasks;
using Hud;
using LevelSystem;
using PopUp.Factory;
using UnityEngine;
using UpgradeSystem;
using VContainer;
using VContainer.Unity;

namespace BootStrap.GameFabric
{
    public class GameFactory : IGameFactory
    {
        private readonly ILoadAssetService _loadAssetService;
        private readonly IProgressUsersService _progressUsersService;
        private readonly IObjectResolver _resolver;
        
        private IClickerModel _clickerModel;
        private IUpgradesMoneyModel _upgradesMoneyModel;
        private ILevelUpgradesModel _levelUpgradesModel;
        private ILevelModel _levelModel;
        
        private ClickerView _clickerView;
        private UpgradesView _upgradesView;
        private LevelView _levelView;
        
        private ClickerPresenter _clikerPresentor;
        private UpgradesPresenter _upgradesPresenter;
        private LevelPresenter _levelPresentor;
        
        private IPopUpFactory _popUpFactory;
        private GameObject _hud;
        private IDisposeService _disposebleService;

        [Inject]
        private void Inject(IClickerModel clickerModel, IUpgradesMoneyModel upgradesMoneyModel,
            IPopUpFactory popUpFactory, ILevelModel levelModel, ILevelUpgradesModel levelUpgradesModel, IDisposeService disposeService)
        {
            _clickerModel = clickerModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _popUpFactory = popUpFactory;
            _levelModel = levelModel;
            _levelUpgradesModel = levelUpgradesModel;
            _disposebleService = disposeService;
        }

        public GameFactory(ILoadAssetService loadAssetService, IProgressUsersService progressUsersService, IObjectResolver resolver)
        {
            _loadAssetService = loadAssetService;
            _progressUsersService = progressUsersService;
            _resolver = resolver;
        }

        public async UniTask<GameObject> CreateHud()
        {
            GameObject hud = await _loadAssetService.GetAsset<GameObject>(PathConstants.HudPath);
           
            _hud = _resolver.Instantiate(hud);
            
            _progressUsersService.RegisterProgressWatchers(_hud);
            
            return _hud;
        }

        public async UniTask<GameObject> CreateClickSystem()
        {
            GameObject clickSystem = await _loadAssetService.GetAsset<GameObject>(PathConstants.ClickSystemPath);
            
            GameObject instantiatedClickSystem = _resolver.Instantiate(clickSystem, _hud.GetComponent<HudView>().ClickSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedClickSystem);

            _clickerView = instantiatedClickSystem.GetComponent<ClickerView>();

            _clikerPresentor = new ClickerPresenter(_clickerModel, _clickerView, _upgradesMoneyModel, _popUpFactory);
            
            _disposebleService.AddDisposableObject(_clikerPresentor);
            
            return instantiatedClickSystem;
        }
        
        public async UniTask<GameObject> CreateUpgradeSystem()
        {
            GameObject upgradeSystem = await _loadAssetService.GetAsset<GameObject>(PathConstants.UpgradeSystemPath);
            
            GameObject instantiatedUpgradeSystem = _resolver.Instantiate(upgradeSystem, _hud.GetComponent<HudView>().UpgradeSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedUpgradeSystem);

            _upgradesView = instantiatedUpgradeSystem.GetComponent<UpgradesView>();

            _upgradesPresenter = new UpgradesPresenter(_upgradesView, _clickerView, _upgradesMoneyModel, _clickerModel, _levelUpgradesModel,
                _levelModel);
            
            _disposebleService.AddDisposableObject(_upgradesPresenter);
            
            return instantiatedUpgradeSystem;
        }
        
        public async UniTask<GameObject> CreateLevelSystem()
        {
            GameObject levelSystem = await _loadAssetService.GetAsset<GameObject>(PathConstants.LevelSystemPath);
           
            GameObject instantiatedLevelSystem = _resolver.Instantiate(levelSystem, _hud.GetComponent<HudView>().LevelSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedLevelSystem);

            _levelView = instantiatedLevelSystem.GetComponent<LevelView>();

            _levelPresentor = new LevelPresenter(_levelView, _levelModel, _upgradesMoneyModel, _levelUpgradesModel, _clikerPresentor);
            
            _disposebleService.AddDisposableObject(_levelPresentor);
            
            return instantiatedLevelSystem;
        }
    }
}