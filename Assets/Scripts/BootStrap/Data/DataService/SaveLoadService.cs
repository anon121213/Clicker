using UnityEngine;

namespace BootStrap.Data.DataService
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IProgressUsersService _progressUsersService;
        private const string ProgresKey = "Progres";
        
        public SaveLoadService(IPersistentProgressService progressService, IProgressUsersService progressUsersService)
        {
            _progressService = progressService;
            _progressUsersService = progressUsersService;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _progressUsersService.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progres);
            
            PlayerPrefs.SetString(ProgresKey, _progressService.Progres.ToJson());
        }

        public PlayerProgres LoadProgress() =>
            PlayerPrefs.GetString(ProgresKey)?
                .ToDesserializeble<PlayerProgres>();
    }
}