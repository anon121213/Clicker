using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreateHud();
        UniTask<GameObject> LoadTest();
    }
}