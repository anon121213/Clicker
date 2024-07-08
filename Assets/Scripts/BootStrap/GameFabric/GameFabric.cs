using System.Threading.Tasks;
using BootStrap.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public class GameFabric : IGameFabric
    {
        private readonly ILoadAsset _loadAsset;

        public GameFabric(ILoadAsset loadAsset)
        {
            _loadAsset = loadAsset;
        }

        public async UniTask<GameObject> CreateHud()
        {
            await _loadAsset.LoadAssets(PathConstants.HudPath);
            
            GameObject hud = _loadAsset.GetAsset<GameObject>("Hud");
            
            if (hud)
                return Object.Instantiate(hud);
            else
                return null;
        }
    }
}