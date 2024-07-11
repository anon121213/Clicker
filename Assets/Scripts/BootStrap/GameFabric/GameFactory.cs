using BootStrap.AssetsLoader;
using BootStrap.AssetsLoader.Services;
using BootStrap.Data.DataService;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public class GameFactory : IGameFactory
    {
        private readonly ILoadAssetService _loadAssetService;
        private readonly IProgressUsersService _progressUsersService;

        public GameFactory(ILoadAssetService loadAssetService, IProgressUsersService progressUsersService)
        {
            _loadAssetService = loadAssetService;
            _progressUsersService = progressUsersService;
        }

        public async UniTask<GameObject> CreateHud()
        {
            GameObject hud = await _loadAssetService.GetAsset<GameObject>(PathConstants.HudPath);

            if (!hud)
                return null;
           
            GameObject InstantiatedHud = Object.Instantiate(hud);

            _progressUsersService.RegisterProgressWatchers(InstantiatedHud);
                    
            return InstantiatedHud;
        }
    }
}