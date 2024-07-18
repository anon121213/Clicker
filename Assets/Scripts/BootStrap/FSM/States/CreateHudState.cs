using System.Collections.Generic;
using BootStrap.Data.DataServices;
using BootStrap.Data.SavesServices;
using BootStrap.GameFabric;
using Cysharp.Threading.Tasks;

namespace BootStrap.FSM.States
{
    public class CreateHudState: IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IProgressUsersService _progressUsersService;
        
        public CreateHudState(IGameFactory gameFactory,
            IPersistentProgressService progressService,
            IProgressUsersService progressUsersService)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
            _progressUsersService = progressUsersService;
        }

        public async void Enter()
        {
            await CreateObjects();
            InformProgressRiders();
        }

        public void Exit() { }

        private async UniTask CreateObjects()
        {
            await _gameFactory.CreateHud();
            await _gameFactory.CreateClickSystem();
            
            List<UniTask> tasks = new List<UniTask>
            {
                _gameFactory.CreateUpgradeSystem(),
                _gameFactory.CreateLevelSystem()
            };

            await UniTask.WhenAll(tasks);
        }
        
        private void InformProgressRiders()
        {
            foreach (ISavedProgressReader progressReader in _progressUsersService.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
    }
}