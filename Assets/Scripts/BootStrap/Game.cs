using BootStrap.FSM;
using BootStrap.GameFabric;
using BootStrap.Services;
using PopUp.Pool;

namespace BootStrap
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, PopUpPool popUpPool, IGameFactory gameFactory, ILoadAsset loadAsset, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), popUpPool, gameFactory, loadAsset, progressService, saveLoadService);
        }
    }
}