using BootStrap.Assets;
using BootStrap.FSM;
using BootStrap.GameFabric;
using Cysharp.Threading.Tasks;
using PopUp.Pool;
using UnityEngine;
using VContainer;

namespace BootStrap
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private PopUpPool _popUpPool;
        private IGameFabric _gameFabric;
        private ILoadAsset _loadAsset;

        [Inject]
        private void Inject(PopUpPool popUpPool, IGameFabric gameFabric, ILoadAsset loadAsset)
        {
            _popUpPool = popUpPool;
            _gameFabric = gameFabric;
            _loadAsset = loadAsset;
        }
        
        private void Awake()
        {
            _game = new Game(this, _popUpPool, _gameFabric, _loadAsset);
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}