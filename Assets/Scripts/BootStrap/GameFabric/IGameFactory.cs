using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressRiters { get; }
        void Cleanup();
    }
}