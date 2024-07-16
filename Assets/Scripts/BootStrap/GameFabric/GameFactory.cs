using BootStrap.AssetsLoader.Services;
using BootStrap.Data.DataServices;
using BootStrap.Data.StaticData;
using ClickSystem;
using Cysharp.Threading.Tasks;
using Hud;
using LevelSystem;
using PopUp.Main;
using UnityEngine;
using UpgradeSystem;
using UpgradeSystem.Models;
using UpgradeSystem.Services.Money;
using UpgradeSystem.Services.Xp;
using VContainer;
using VContainer.Unity;

namespace BootStrap.GameFabric
{
    public class GameFactory : IGameFactory
    {
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
        
        private GameObject _hud;
        private IDisposeService _disposebleService;

        private AssetsReferences _assets;
        private readonly IClickService _clickService;
        private readonly IPopUpCreateService _popUpCreateService;
        private readonly IUpgradeClickPriceService _upgradeClickPriceService;
        private IUpgradeClickXpService _upgradeClickXpService;

        public GameFactory(ILoadAssetService loadAssetService, IProgressUsersService progressUsersService,
            IObjectResolver resolver, IStaticDataProvider dataProvider, IClickService clickService,
            IPopUpCreateService popUpCreateService, IUpgradeClickPriceService upgradeClickPriceService,
            IClickerModel clickerModel, IUpgradesMoneyModel upgradesMoneyModel,
            ILevelModel levelModel, ILevelUpgradesModel levelUpgradesModel, 
            IDisposeService disposeService, IUpgradeClickXpService upgradeClickXpService)
        {
            _clickerModel = clickerModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _levelModel = levelModel;
            _levelUpgradesModel = levelUpgradesModel;
            _disposebleService = disposeService;
            _upgradeClickXpService = upgradeClickXpService;
            _progressUsersService = progressUsersService;
            _resolver = resolver;
            _assets = dataProvider.AssetsReferences;
            _clickService = clickService;
            _popUpCreateService = popUpCreateService;
            _upgradeClickPriceService = upgradeClickPriceService;
        }

        public async UniTask<GameObject> CreateHud()
        {
            GameObject prefab = await _assets.Hud.LoadAssetAsync<GameObject>();
            
            _hud = _resolver.Instantiate(prefab);
            
            _progressUsersService.RegisterProgressWatchers(_hud);
            
            return _hud;
        }

        public async UniTask<GameObject> CreateClickSystem()
        {
            GameObject clickSystem = await _assets.ClickSystem.LoadAssetAsync<GameObject>();
            
            GameObject instantiatedClickSystem = _resolver.Instantiate(clickSystem, _hud.GetComponent<HudView>().ClickSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedClickSystem);

            _clickerView = instantiatedClickSystem.GetComponent<ClickerView>();

            _clikerPresentor = new ClickerPresenter(_clickerModel, _clickerView, _upgradesMoneyModel, _clickService, _popUpCreateService);
            
            _disposebleService.AddDisposableObject(_clikerPresentor);
            
            return instantiatedClickSystem;
        }
        
        public async UniTask<GameObject> CreateUpgradeSystem()
        {
            GameObject upgradeSystem = await _assets.UpgradeSystem.LoadAssetAsync<GameObject>();
            
            GameObject instantiatedUpgradeSystem = _resolver.Instantiate(upgradeSystem, _hud.GetComponent<HudView>().UpgradeSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedUpgradeSystem);

            _upgradesView = instantiatedUpgradeSystem.GetComponent<UpgradesView>();

            _upgradesPresenter = new UpgradesPresenter(_upgradesView, _clickerView, _upgradesMoneyModel,
                _clickerModel, _levelUpgradesModel, _levelModel, _upgradeClickPriceService, _upgradeClickXpService);
            
            _disposebleService.AddDisposableObject(_upgradesPresenter);
            
            return instantiatedUpgradeSystem;
        }
        
        public async UniTask<GameObject> CreateLevelSystem()
        {
            GameObject levelSystem = await _assets.LevelSystem.LoadAssetAsync<GameObject>();
            
            GameObject instantiatedLevelSystem = _resolver.Instantiate(levelSystem, _hud.GetComponent<HudView>().LevelSystemRoot);

            _progressUsersService.RegisterProgressWatchers(instantiatedLevelSystem);

            _levelView = instantiatedLevelSystem.GetComponent<LevelView>();

            _levelPresentor = new LevelPresenter(_levelView, _levelModel, _upgradesMoneyModel, _levelUpgradesModel, _clikerPresentor);
            
            _disposebleService.AddDisposableObject(_levelPresentor);
            
            return instantiatedLevelSystem;
        }
    }
}