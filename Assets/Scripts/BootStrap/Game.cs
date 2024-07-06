using PopUp.Pool;

namespace BootStrap
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, PopUpPool popUpPool)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), popUpPool);
        }
    }
}