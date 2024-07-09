using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace BootStrap.GameFabric
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreateHud();
        UniTask<GameObject> LoadTest();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}