using BootStrap.AssetsLoader.Services;
using BootStrap.Data.DataServices;
using BootStrap.Data.StaticData;
using ClickSystem;
using Cysharp.Threading.Tasks;
using Hud;
using LevelSystem;
using UnityEngine;
using UpgradeSystem;
using VContainer;
using VContainer.Unity;

namespace BootStrap.GameFabric
{
    public class GameFactory : IGameFactory
    {
        private readonly IProgressUsersService _progressUsersService;
        private readonly IObjectResolver _resolver;
        private readonly IDisposeService _disposebleService;
        private readonly ILoadAssetService _loadAssetService;
        
        private ClickerView _clickerView;
        private UpgradesView _upgradesView;
        private LevelView _levelView;
        
        private readonly ClickerPresenter _clickerPresenter;
        private readonly UpgradesPresenter _upgradesPresenter;
        private readonly LevelPresenter _levelPresenter;
        
        private readonly AssetsReferences _assets;

        private GameObject _hud;

        public GameFactory(IProgressUsersService progressUsersService,
            IObjectResolver resolver,
            IStaticDataProvider dataProvider,
            IDisposeService disposeService,
            ILoadAssetService loadAssetService,
            ClickerPresenter clickerPresenter,
            LevelPresenter levelPresenter,
            UpgradesPresenter upgradesPresenter)
        {
            _disposebleService = disposeService;
            _loadAssetService = loadAssetService;
            _levelPresenter = levelPresenter;
            _upgradesPresenter = upgradesPresenter;
            _clickerPresenter = clickerPresenter;
            _progressUsersService = progressUsersService;
            _resolver = resolver;
            _assets = dataProvider.AssetsReferences;
        }

        public async UniTask<GameObject> CreateHud()
        {
            GameObject prefab = await _loadAssetService.GetAsset<GameObject>(_assets.Hud);
            
            _hud = _resolver.Instantiate(prefab);
            
            _progressUsersService.RegisterProgressWatchers(_hud);
            
            return _hud;
        }

        public async UniTask<GameObject> CreateClickSystem()
        {
            GameObject clickSystem = await _loadAssetService.GetAsset<GameObject>(_assets.ClickSystem);
            
            GameObject instantiatedClickSystem = _resolver.Instantiate(clickSystem, _hud.GetComponent<HudView>().ClickSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedClickSystem);

            _clickerView = instantiatedClickSystem.GetComponent<ClickerView>();
            
            _clickerPresenter.Constructor(_clickerView);
            
            _clickerPresenter.Start();
            
            _disposebleService.AddDisposableObject(_clickerPresenter);
            
            return instantiatedClickSystem;
        }
        
        public async UniTask<GameObject> CreateUpgradeSystem()
        {
            GameObject upgradeSystem = await _loadAssetService.GetAsset<GameObject>(_assets.UpgradeSystem);
            
            GameObject instantiatedUpgradeSystem = _resolver.Instantiate(upgradeSystem, _hud.GetComponent<HudView>().UpgradeSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedUpgradeSystem);

            _upgradesView = instantiatedUpgradeSystem.GetComponent<UpgradesView>();
            
            _upgradesPresenter.Constructor(_upgradesView, _clickerView);
            
            _upgradesPresenter.Start();
            
            _disposebleService.AddDisposableObject(_upgradesPresenter);
            
            return instantiatedUpgradeSystem;
        }
        
        public async UniTask<GameObject> CreateLevelSystem()
        {
            GameObject levelSystem = await _loadAssetService.GetAsset<GameObject>(_assets.LevelSystem);
            
            GameObject instantiatedLevelSystem = _resolver.Instantiate(levelSystem, _hud.GetComponent<HudView>().LevelSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedLevelSystem);

            _levelView = instantiatedLevelSystem.GetComponent<LevelView>();
            
            _levelPresenter.Constructor(_levelView);
            
            _levelPresenter.Start();
            
            _disposebleService.AddDisposableObject(_levelPresenter);
            
            return instantiatedLevelSystem;
        }
    }
}