using BootStrap.Bootstap;
using BootStrap.Data.DataServices;
using BootStrap.Data.StaticData;
using BootStrap.GameFabric;
using UnityEngine.AddressableAssets;

namespace BootStrap.FSM.States
{
    public class LoadLevelState: IPayloadedState<AssetReference>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IProgressUsersService _progressUsersService;
        private readonly PlayerProgress _progress;

        public LoadLevelState(SceneLoader sceneLoader,
            IProgressUsersService progressUsersService)
        {
            _sceneLoader = sceneLoader;
            _progressUsersService = progressUsersService;
        }

        public async void Enter(AssetReference nextScene)
        {
            _progressUsersService.Cleanup();
            await _sceneLoader.Load(nextScene);
        }

        public void Exit() { }
    }
}