using System.Collections.Generic;
using BootStrap.Data.SavesServices;
using UnityEngine;

namespace BootStrap.Data.DataServices
{
    public interface IProgressUsersService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void RegisterProgressWatchers(GameObject instantiatedGameObject);
        void Cleanup();
    }
}