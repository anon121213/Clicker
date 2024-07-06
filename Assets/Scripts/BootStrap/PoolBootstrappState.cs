using PopUp.Pool;

namespace BootStrap
{
    public class PoolBootstrappState: IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PopUpPool _popUpPool;

        public PoolBootstrappState(GameStateMachine gameStateMachine, PopUpPool popUpPool)
        {
            _gameStateMachine = gameStateMachine;
            _popUpPool = popUpPool;
        }

        public void Enter() =>
            _popUpPool.Warmup();

        public void Exit()
        {
        }
    }
}