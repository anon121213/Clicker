using BootStrap.Assets;

namespace BootStrap.FSM
{
    public class BootstrapState: IState
    {
        private const string Bootstrap = "Bootstrap";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ILoadAsset _loadAsset;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ILoadAsset loadAsset)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadAsset = loadAsset;
        }
        
        public async void Enter()
        {
            await _loadAsset.LoadAssets();
            _sceneLoader.Load(Bootstrap, EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadLevelState, string>("MainLvL");


        public void Exit()
        {
        }
    }
}