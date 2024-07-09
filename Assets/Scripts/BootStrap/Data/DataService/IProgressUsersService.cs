using System.Collections.Generic;

namespace BootStrap.Data.DataService
{
    public interface IProgressUsersService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Register(ISavedProgressReader progressReader);
        void Cleanup();
    }
}