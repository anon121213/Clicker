using System.Collections.Generic;
using System.Threading.Tasks;
using BootStrap.Bootstap;
using BootStrap.Data.DataServices;
using BootStrap.Data.SavesServices;
using BootStrap.Data.StaticData;
using BootStrap.GameFabric;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace BootStrap.FSM.States
{
    public class LoadLevelState: IPayloadedState<AssetReference>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IProgressUsersService _progressUsersService;
        private readonly PlayerProgress _progress;
        
        private GameObject _hud;

        public LoadLevelState(SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService, IProgressUsersService progressUsersService)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _progressUsersService = progressUsersService;
        }

        public async void Enter(AssetReference nextScene)
        {
            _progressUsersService.Cleanup();
            await _sceneLoader.Load(nextScene, OnLoaded);
        }

        private async void OnLoaded()
        {
            _hud = await CreateObjects();
            InformProgressRiders();
            SceneManager.MoveGameObjectToScene(_hud, SceneManager.GetActiveScene());
        }

        private async UniTask<GameObject> CreateObjects()
        {
            GameObject hud = await _gameFactory.CreateHud();
            await _gameFactory.CreateClickSystem();
            
            List<UniTask> tasks = new List<UniTask>
            {
                _gameFactory.CreateUpgradeSystem(),
                _gameFactory.CreateLevelSystem()
            };

            await UniTask.WhenAll(tasks);
            return hud;
        }

        private void InformProgressRiders()
        {
            foreach (ISavedProgressReader progressReader in _progressUsersService.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        public void Exit()
        {
        }
    }
}