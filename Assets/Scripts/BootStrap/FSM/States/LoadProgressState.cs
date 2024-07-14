using BootStrap.AssetsLoader.Services;
using BootStrap.Data.DataServices;
using BootStrap.Data.References;
using BootStrap.Data.SavesServices;
using UnityEngine.AddressableAssets;
using VContainer;

namespace BootStrap.FSM.States
{
    public class LoadProgressState : IState
    {
        [Inject] private ILoadAssetService _loadAssetService;
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        
        private AssetsReferences _assets;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService,
            ISaveLoadService saveLoadService, AssetsReferences assets)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _assets = assets;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _gameStateMachine.Enter<LoadLevelState, AssetReference>(_assets.MainScene);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew() =>
            _progressService.Progress =
                _saveLoadService.LoadProgress() ??
                NewProgress();

        private PlayerProgress NewProgress() => 
            new();
    }
}