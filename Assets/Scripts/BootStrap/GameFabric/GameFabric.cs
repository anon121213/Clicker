using BootStrap.Assets;
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

        public GameObject CreateHud()
        {
            GameObject hud = _loadAsset.GetAsset<GameObject>("Hud");
            if (hud)
                return Object.Instantiate(hud);
            else
                return null;
        }
    }
}