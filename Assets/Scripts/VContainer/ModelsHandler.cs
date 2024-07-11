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
        private ClickerView _clickerView;
        private UpgradesModel _upgradesModel;
        private IPopUpFactory _popUpFactory;
        private ClickerModel _clickerModel;

        [Inject]
        private void Inject(ClickerView clickerView, UpgradesModel upgradesModel, IPopUpFactory popUpFactory)
        {
            _clickerView = clickerView;
            _upgradesModel = upgradesModel;
            _popUpFactory = popUpFactory;
        }

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