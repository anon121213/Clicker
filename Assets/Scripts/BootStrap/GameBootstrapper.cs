using BootStrap.FSM;
using BootStrap.GameFabric;
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

        [Inject]
        private void Inject(PopUpPool popUpPool, IGameFabric gameFabric)
        {
            _popUpPool = popUpPool;
            _gameFabric = gameFabric;
        }
        
        public void Awake()
        {
            _game = new Game(this, _popUpPool, _gameFabric);
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}