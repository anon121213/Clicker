using BootStrap.Assets;
using BootStrap.FSM;
using BootStrap.GameFabric;
using PopUp.Pool;

namespace BootStrap
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, PopUpPool popUpPool, IGameFabric gameFabric, ILoadAsset loadAsset)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), popUpPool, gameFabric, loadAsset);
        }
    }
}