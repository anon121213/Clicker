using BootStrap.GameFabric;
using Data;
using UnityEngine;

namespace BootStrap.Services
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;
        private const string ProgresKey = "Progres";
        
        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
            {
                progressWriter.UpdateProgress(_progressService.Progres);
            }
            
            PlayerPrefs.SetString(ProgresKey, _progressService.Progres.ToJson());
        }

        public PlayerProgres LoadProgress() =>
            PlayerPrefs.GetString(ProgresKey)?
                .ToDesserializeble<PlayerProgres>();
    }
}