using System.Collections;
using PopUp.Pool;
using UnityEngine;
using VContainer;

namespace BootStrap
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private PopUpPool _popUpPool;

        [Inject]
        private void Inject(PopUpPool popUpPool)
        {
            _popUpPool = popUpPool;
        }
        
        public void Awake()
        {
            _game = new Game(this, _popUpPool);
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}