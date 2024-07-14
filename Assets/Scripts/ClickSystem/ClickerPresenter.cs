using Hud;
using PopUp.Main;
using UnityEngine;
using UnityEngine.UI;
using UpgradeSystem;

namespace ClickSystem
{
    public class ClickerPresenter: IPresentor
    {
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;
        private readonly IClickerModel _clickerModel;
        
        private readonly ClickerView _clikerView;
        
        private readonly Transform _popUpRoot;
        private readonly IClickService _clickService;
        private readonly IPopUpCreateService _popUpCreateService;

        public Button ClickButton;

        public ClickerPresenter(IClickerModel clickerModel, ClickerView clickerView,
            IUpgradesMoneyModel upgradesMoneyModel, IClickService clickService,
            IPopUpCreateService popUpCreateService)
        {
            _clikerView = clickerView;
            _clickerModel = clickerModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _clickService = clickService;
            _popUpCreateService = popUpCreateService;
            _popUpRoot = clickerView._popUpRoot;
            
            Start();
        }
        
        private void Start()
        {
            _clickerModel.OnValueChanged += UpdateUi;
            
            ClickButton = _clikerView._clickButton;
            ClickButton.onClick.AddListener(Click);
            
            UpdateUi();
        }
        
        private void Click()
        {
            _clickService.OnClick();
            _popUpCreateService.CreatePopUp(_popUpRoot);
        }

        private void UpdateUi() =>
            _clikerView.UpdateClickCount(_clickerModel.Money);
        
        public void Disable()
        {
            _clickerModel.OnValueChanged -= UpdateUi;
        }
    }
}