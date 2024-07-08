using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public interface IGameFabric
    {
        UniTask<GameObject> CreateHud();
    }
}