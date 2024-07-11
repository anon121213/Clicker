using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreateHud();
    }
}