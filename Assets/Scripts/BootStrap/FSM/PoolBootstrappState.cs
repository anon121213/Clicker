using PopUp.Pool;

namespace BootStrap.FSM
{
    public class PoolBootstrappState: IState
    {
        private readonly PopUpPool _popUpPool;

        public PoolBootstrappState(PopUpPool popUpPool)
        {
            _popUpPool = popUpPool;
        }

        public void Enter() =>
            _popUpPool.Warmup();

        public void Exit()
        {
        }
    }
}