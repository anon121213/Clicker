using System.Collections.Generic;
using BootStrap.Assets;
using BootStrap.AssetsLoader.Services;
using BootStrap.Data;
using BootStrap.Data.DataService;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public class GameFactory : IGameFactory
    {
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
            
            GameObject hud = _loadAssetService.GetAsset<GameObject>("Hud");

            if (!hud)
                return null;
           
            GameObject InstantiatedHud = Object.Instantiate(hud);

            RegisterProgressWatchers(InstantiatedHud);
                    
            return InstantiatedHud;
        }
        
        public async UniTask<GameObject> LoadTest()
        {
            await _loadAssetService.LoadAsset(PathConstants.LoadTestPath);
            
            GameObject loadTest = _loadAssetService.GetAsset<GameObject>("SaveTest");

            if (!loadTest)
                return null;
                
            GameObject InstantiatedloadTest = Object.Instantiate(loadTest);

            RegisterProgressWatchers(InstantiatedloadTest);
                
            return InstantiatedloadTest;
        }

        private void RegisterProgressWatchers(GameObject instantiatedGameObject)
        {
            foreach (ISavedProgressReader progressReader in instantiatedGameObject.GetComponentsInChildren<ISavedProgressReader>())
                _progressUsersService.Register(progressReader);
        }

        
    }
}