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
        private readonly ILoadAsset _loadAsset;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameFactory(ILoadAsset loadAsset) =>
            _loadAsset = loadAsset;

        public async UniTask<GameObject> CreateHud()
        {
            await _loadAsset.LoadAsset(PathConstants.HudPath);
            
            GameObject hud = _loadAsset.GetAsset<GameObject>("Hud");
            
            if (hud)
            {
                GameObject InstantiatedHud = Object.Instantiate(hud);

                RegisterProgressWatchers(InstantiatedHud);
                
                return InstantiatedHud;
            }
            else
                return null;
        }
        
        public async UniTask<GameObject> LoadTest()
        {
            await _loadAsset.LoadAsset(PathConstants.LoadTestPath);
            
            GameObject loadTest = _loadAsset.GetAsset<GameObject>("SaveTest");
            
            if (loadTest)
            {
                GameObject InstantiatedloadTest = Object.Instantiate(loadTest);

                RegisterProgressWatchers(InstantiatedloadTest);
                
                return InstantiatedloadTest;
            }
            else
                return null;
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