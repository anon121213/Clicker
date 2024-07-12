using System.Collections.Generic;
using System.Threading.Tasks;
using BootStrap.Bootstap;
using BootStrap.Data;
using BootStrap.Data.DataService;
using BootStrap.GameFabric;
using Cysharp.Threading.Tasks;

namespace BootStrap.FSM.States
{
    public class LoadLevelState: IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IProgressUsersService _progressUsersService;
        private readonly PlayerProgres _progres;

        public LoadLevelState(SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService, IProgressUsersService progressUsersService)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _progressUsersService = progressUsersService;
        }

        public void Enter(string name)
        {
            _progressUsersService.Cleanup();
            _sceneLoader.Load(name, OnLoaded);
        }

        private async void OnLoaded()
        {
            await CreateObjects();
            InformProgressRiders();
        }

        private async Task CreateObjects()
        {
            List<UniTask> tasks = new List<UniTask>
            {
                _gameFactory.CreateHud(),
                _gameFactory.CreateClickSystem(),
                _gameFactory.CreateUpgradeSystem(),
                _gameFactory.CreateLevelSystem()
            };

            await UniTask.WhenAll(tasks);
        }

        private void InformProgressRiders()
        {
            foreach (ISavedProgressReader progressReader in _progressUsersService.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progres);
        }

        public void Exit()
        {
        }
    }
}