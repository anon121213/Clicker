using BootStrap.Data;
using ClickSystem;
using LevelSystem;
using ModelsFactory;
using UnityEngine;

namespace VContainer
{
    public class SavesHandler : MonoBehaviour, ISavedProgress
    {
        [Inject] private IModelsFactory _modelsFactory;
        
        private int _money;
        private int _level;
        private int _clicksForNewLvl;
        private int _currentClicks;
        
        private ClickerModel _clickerModel;
        private LevelModel _levelModel;

        private void Start()
        {
            CreateModels();
            SetLoadValue();
        }

        private void CreateModels()
        {
            //создать стэйт для создания моделей
            _clickerModel = _modelsFactory.CreateClickModel();
            _levelModel = _modelsFactory.CreateLevelModel();
        }

        private void SetLoadValue()
        {
            _clickerModel.IncrementMoneyCount(_money);
            
            _levelModel.IncrementLvL(_level);
            _levelModel.ClicksForNewLvl = _clicksForNewLvl;
            _levelModel.IncrementClicks(_currentClicks);
        }

        public void LoadProgress(PlayerProgres progress)
        {
            _money = progress.Money;
            _level = progress.CurrentLvl;
            _clicksForNewLvl = progress.ClicksForNewLvl;
            _currentClicks = progress.CurrentClicks;
        }

        public void UpdateProgress(PlayerProgres progres)
        {
            progres.Money = _clickerModel.GetMoneyCount();
            progres.CurrentLvl = _levelModel.GetCurrentLvL();
            progres.ClicksForNewLvl = _levelModel.ClicksForNewLvl;
        }
    }
}