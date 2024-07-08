using BootStrap.Assets;

namespace BootStrap.FSM
{
    public class BootstrapState: IState
    {
        private const string Bootstrap = "Bootstrap";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.Load(Bootstrap, EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadProgressState>();


        public void Exit()
        {
        }
    }
}