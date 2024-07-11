using BootStrap.Data;
using ClickSystem;
using PopUp.Factory;
using UnityEngine;
using UpgradeSystem;

namespace VContainer
{
    public class ModelsHandler : MonoBehaviour, ISavedProgress
    {
        private int _money;
        [Inject] private ClickerView _clickerView;
        [Inject] private UpgradesModel _upgradesModel;
        [Inject] private IPopUpFactory _popUpFactory;
        private ClickerModel _clickerModel;

        private void Start()
        {
            CreateModels();
        }

        private void CreateModels()
        {
            _clickerModel = new ClickerModel(_clickerView, _upgradesModel, _popUpFactory, _money);
        }

        public void LoadProgress(PlayerProgres progress)
        {
            _money = progress.Money;
        }

        public void UpdateProgress(PlayerProgres progres)
        {
            progres.Money = _clickerModel.Money;
        }
    }
}