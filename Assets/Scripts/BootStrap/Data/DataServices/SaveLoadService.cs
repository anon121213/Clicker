using BootStrap.Data.Esxtentions;
using BootStrap.Data.SavesServices;
using BootStrap.Data.StaticData;
using UnityEngine;

namespace BootStrap.Data.DataServices
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IProgressUsersService _progressUsersService;
        private const string ProgressKey = "Progress";
        
        public SaveLoadService(IPersistentProgressService progressService, IProgressUsersService progressUsersService)
        {
            _progressService = progressService;
            _progressUsersService = progressUsersService;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _progressUsersService.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDesserializeble<PlayerProgress>();
    }
}