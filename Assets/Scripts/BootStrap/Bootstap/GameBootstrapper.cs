using BootStrap.FSM;
using BootStrap.GameFabric;
using BootStrap.Services;
using UnityEngine;
using VContainer;

namespace BootStrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        [Inject]
        private void Inject(IGameFactory gameFactory, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }
        
        private void Awake()
        {
            SceneLoader sceneLoader = new SceneLoader();
            GameStateMachine gameStateMachine = new GameStateMachine();
            
            AddStates(gameStateMachine, sceneLoader);
            gameStateMachine.Enter<BootstrapState>();
        }

        private void OnApplicationQuit()
        {
            _saveLoadService.SaveProgress();
        }

        private void AddStates(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            gameStateMachine.AddState(typeof(BootstrapState), new BootstrapState(gameStateMachine, sceneLoader));
            gameStateMachine.AddState(typeof(LoadProgressState), new LoadProgressState(gameStateMachine, _progressService, _saveLoadService));
            gameStateMachine.AddState(typeof(LoadLevelState), new LoadLevelState(sceneLoader, _gameFactory, _progressService));
        }
    }
}