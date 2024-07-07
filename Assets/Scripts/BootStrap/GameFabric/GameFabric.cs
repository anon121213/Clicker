using UnityEngine;

namespace BootStrap.GameFabric
{
    public class GameFabric : IGameFabric
    {
        private readonly ICreateAsset _createAsset;

        public GameFabric(ICreateAsset createAsset)
        {
            _createAsset = createAsset;
        }

        public GameObject CreateHud()
        {
            return _createAsset.Instantiate(PathConstants.HudPath);
        }
    }
}