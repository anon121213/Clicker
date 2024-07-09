using System.Collections.Generic;
using BootStrap.Assets;
using BootStrap.Services;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public class GameFactory : IGameFactory
    {
        private readonly ILoadAssetService _loadAssetService;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameFactory(ILoadAssetService loadAssetService) =>
            _loadAssetService = loadAssetService;

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

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private void RegisterProgressWatchers(GameObject instantiatedGameObject)
        {
            foreach (ISavedProgressReader progressReader in instantiatedGameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}