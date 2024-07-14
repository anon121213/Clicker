using System.Collections.Generic;
using BootStrap.Data.SavesServices;
using UnityEngine;

namespace BootStrap.Data.DataServices
{
    public class ProgressUsersService : IProgressUsersService
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();
        
        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        public void RegisterProgressWatchers(GameObject instantiatedGameObject)
        {
            foreach (ISavedProgressReader progressReader in instantiatedGameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}