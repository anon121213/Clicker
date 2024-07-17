using BootStrap.AssetsLoader.Services;
using BootStrap.Data.DataServices;
using BootStrap.Data.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using VContainer;

namespace BootStrap.FSM.States
{
    public class LoadProgressState : IState
    {
        private readonly ILoadAssetService _loadAssetService;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly ILoadDefaultProgress _loadDefaultProgress;

        private readonly GameStateMachine _gameStateMachine;
        private readonly AssetsReferences _assets;

        public LoadProgressState(GameStateMachine gameStateMachine,
            IPersistentProgressService progressService,
            ISaveLoadService saveLoadService,
            IStaticDataProvider dataProvider,
            ILoadDefaultProgress loadDefaultProgress,
            ILoadAssetService loadAssetService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _loadDefaultProgress = loadDefaultProgress;
            _loadAssetService = loadAssetService;
            _assets = dataProvider.AssetsReferences;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, AssetReference>(_assets.MainScene);
        }

        public void Exit() { }

        private async void LoadProgressOrInitNew() =>
            _progressService.Progress = 
                _saveLoadService.LoadProgress() 
                ?? await NewProgress();

        private async UniTask<PlayerProgress>  NewProgress()
        {
            PlayerProgress progress = new();
            _loadDefaultProgress.SetDefaultSettings(progress);
            return progress;
        }
    }
}