using System.Collections.Generic;
using UnityEngine;

namespace BootStrap.Data.DataService
{
    public interface IProgressUsersService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void RegisterProgressWatchers(GameObject instantiatedGameObject);
        void Cleanup();
    }
}