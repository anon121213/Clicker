using BootStrap.FSM;
using BootStrap.GameFabric;
using BootStrap.Services;
using Data;
using PopUp.Pool;
using UnityEngine;
using VContainer;

namespace BootStrap
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private PopUpPool _popUpPool;
        private IGameFactory _gameFactory;
        private ILoadAsset _loadAsset;
        private IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        [Inject]
        private void Inject(PopUpPool popUpPool, IGameFactory gameFactory, ILoadAsset loadAsset, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _popUpPool = popUpPool;
            _gameFactory = gameFactory;
            _loadAsset = loadAsset;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }
        
        private void Awake()
        {
            _game = new Game(this, _popUpPool, _gameFactory, _loadAsset, _progressService, _saveLoadService);
            _game.StateMachine.Enter<BootstrapState>();
        }

        private void OnApplicationQuit()
        {
            _saveLoadService.SaveProgress();
        }
    }
}