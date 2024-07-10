using BootStrap.AssetsLoader;
using BootStrap.AssetsLoader.Services;
using BootStrap.Data.DataService;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public class GameFactory : IGameFactory
    {
        private const string Hud = "Hud";
        private const string SaveTest = "SaveTest";
        
        private readonly ILoadAssetService _loadAssetService;
        private readonly IProgressUsersService _progressUsersService;

        public GameFactory(ILoadAssetService loadAssetService, IProgressUsersService progressUsersService)
        {
            _loadAssetService = loadAssetService;
            _progressUsersService = progressUsersService;
        }

        public async UniTask<GameObject> CreateHud()
        {
            await _loadAssetService.LoadAsset(PathConstants.HudPath);
            
            GameObject hud = _loadAssetService.GetAsset<GameObject>(Hud);

            if (!hud)
                return null;
           
            GameObject InstantiatedHud = Object.Instantiate(hud);

            _progressUsersService.RegisterProgressWatchers(InstantiatedHud);
                    
            return InstantiatedHud;
        }
        
        public async UniTask<GameObject> LoadTest()
        {
            await _loadAssetService.LoadAsset(PathConstants.LoadTestPath);
            
            GameObject loadTest = _loadAssetService.GetAsset<GameObject>(SaveTest);

            if (!loadTest)
                return null;
                
            GameObject InstantiatedloadTest = Object.Instantiate(loadTest);

            _progressUsersService.RegisterProgressWatchers(InstantiatedloadTest);
                
            return InstantiatedloadTest;
        }
    }
}