using BootStrap.Data.DataServices;
using BootStrap.Data.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace BootStrap.FSM.States
{
    public class LoadProgressState : IState
    {
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly ILoadDefaultProgress _loadDefaultProgress;

        private readonly GameStateMachine _gameStateMachine;
        private readonly AssetsReferences _assets;

        public LoadProgressState(GameStateMachine gameStateMachine,
            IPersistentProgressService progressService,
            ISaveLoadService saveLoadService,
            IStaticDataProvider dataProvider,
            ILoadDefaultProgress loadDefaultProgress)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _loadDefaultProgress = loadDefaultProgress;
            _assets = dataProvider.AssetsReferences;
        }

        public async void Enter()
        {
            await LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, AssetReference>(_assets.MainScene);
        }

        public void Exit() { }

        private async UniTask LoadProgressOrInitNew() =>
            _progressService.Progress = 
                _saveLoadService.LoadProgress() 
                ?? NewProgress();

        private PlayerProgress  NewProgress()
        {
            PlayerProgress progress = new();
            _loadDefaultProgress.SetDefaultSettings(progress);
            return progress;
        }
    }
}