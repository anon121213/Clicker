﻿using System.Collections.Generic;

namespace BootStrap.Data.DataService
{
    public class ProgressUsersService : IProgressUsersService
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        
        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
        
        public void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}