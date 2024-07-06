namespace BootStrap
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
            RegisterServices();
            _sceneLoader.Load(Bootstrap, EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadLevelState, string>("MainLvL");

        private void RegisterServices()
        {
        }

        public void Exit()
        {
        }
    }
}