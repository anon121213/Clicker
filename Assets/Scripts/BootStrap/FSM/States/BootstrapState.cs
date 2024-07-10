using BootStrap.AssetsLoader.Services;
using BootStrap.Bootstap;

namespace BootStrap.FSM.States
{
    public class BootstrapState: IState
    {
        private const string Bootstrap = "Bootstrap";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ILoadAssetService _loadAssetService;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ILoadAssetService loadAssetService)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadAssetService = loadAssetService;
        }
        
        public void Enter()
        {
            //_sceneLoader.Load(Bootstrap, EnterLoadLevel);
            _gameStateMachine.Enter<LoadProgressState>();
        }

        /*private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadProgressState>();*/


        public void Exit()
        {
        }
    }
}