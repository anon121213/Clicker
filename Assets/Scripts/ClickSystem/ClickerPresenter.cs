using LevelSystem;
using PopUp.Factory;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using UpgradeSystem;

namespace ClickSystem
{
    public class ClickerPresenter
    {
        private readonly LevelUpgradesModel _levelUpgradesModel;
        private readonly UpgradesMoneyModel _upgradesMoneyModel;
        private readonly ClickerModel _clickerModel;
        private readonly LevelModel _levelModel;
        
        private readonly ClickerView _clikerView;
        
        private readonly AudioClip _clickSound;
        private readonly Transform _popUpRoot;
        private readonly IPopUpFactory _popUpFactory;

        public Button ClickButton;

        public ClickerPresenter(ClickerModel clickerModel, ClickerView clikerView, UpgradesMoneyModel upgradesMoneyModel, IPopUpFactory popUpFactory)
        {
            _clikerView = clikerView;
            _clickerModel = clickerModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _popUpFactory = popUpFactory;
            _clickSound = clikerView._clickSound;
            _popUpRoot = clikerView._popUpRoot;
            Start();
        }
        
        private void Start()
        {
            _clikerView.UpdateClickCount(_clickerModel.Money);
            ClickButton = _clikerView._clickButton;
            ClickButton.onClick.AddListener(Click);
            _clickerModel.OnValueChanged += UpdateUi;
        }
        
        private void Click()
        {
            PlaySFX.instance.PlayMusic(_clickSound);
            _clickerModel.AddMoney(_upgradesMoneyModel.ClickPrice);
        
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                var clickPosition = touch.position;
                /*PopUpCountChanger popUp = _popUpFactory.Create(clickPosition, _popUpRoot, quaternion.identity);
                popUp.Enable();*/
            }
        }

        private void UpdateUi() =>
            _clikerView.UpdateClickCount(_clickerModel.Money);

        public void Disable() =>
            _clickerModel.OnValueChanged -= UpdateUi;
    }
}