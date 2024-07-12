using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreateHud();
        UniTask<GameObject> CreateClickSystem();
        UniTask<GameObject> CreateUpgradeSystem();
        UniTask<GameObject> CreateLevelSystem();
    }
}