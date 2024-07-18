using System;
using BootStrap.Data.DataServices;
using BootStrap.FSM;
using BootStrap.FSM.States;
using VContainer;
using VContainer.Unity;

namespace BootStrap.Bootstap
{
    public class GameBootstrapper : IDisposable, IStartable
    {
        private ISaveLoadService _saveLoadService;
        private BootstrapState _bootstrapState;
        private LoadProgressState _loadProgressState;
        private LoadLevelState _loadLevelState;
        private GameStateMachine _gameStateMachine;
        
        [Inject]
        private void Inject(BootstrapState bootstrapState,
            LoadProgressState loadProgressState,
            LoadLevelState loadLevelState,
            ISaveLoadService saveLoadService,
            GameStateMachine gameStateMachine)
        {
            _bootstrapState = bootstrapState;
            _loadProgressState = loadProgressState;
            _loadLevelState = loadLevelState;
            _saveLoadService = saveLoadService;
            _gameStateMachine = gameStateMachine;
        }

        public void Start()
        {
            AddStates(_gameStateMachine);
            _gameStateMachine.Enter<BootstrapState>();
        }

        public void Dispose() =>
            _saveLoadService.SaveProgress();

        private void AddStates(GameStateMachine gameStateMachine)
        {
            gameStateMachine.AddState(typeof(BootstrapState), _bootstrapState);
            gameStateMachine.AddState(typeof(LoadProgressState), _loadProgressState);
            gameStateMachine.AddState(typeof(LoadLevelState), _loadLevelState);
        }
    }
}