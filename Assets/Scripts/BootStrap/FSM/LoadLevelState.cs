using System.Collections.Generic;
using System.Threading.Tasks;
using BootStrap.GameFabric;
using BootStrap.Services;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace BootStrap.FSM
{
    public class LoadLevelState: IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly PlayerProgres _progres;

        public LoadLevelState(SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string name)
        {
            _gameFactory.Cleanup();
            _sceneLoader.Load(name, OnLoaded);
        }

        private async void OnLoaded()
        {
            await CreateObjects();
            InformProgressRiders();
        }

        private async Task CreateObjects()
        {
            List<UniTask> tasks = new List<UniTask>();
            
            tasks.Add(_gameFactory.CreateHud());
            tasks.Add(_gameFactory.LoadTest());

            await UniTask.WhenAll(tasks);
        }

        private void InformProgressRiders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_progressService.Progres);
            }
        }

        public void Exit()
        {
        }
    }
}