using System;
using PopUp.Main;
using UnityEngine;
using UnityEngine.UI;
using UpgradeSystem.Models;

namespace ClickSystem
{
    public class ClickerPresenter: IDisposable
    {
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;
        private readonly IClickerModel _clickerModel;
        
        private ClickerView _clikerView;
        
        private readonly IClickService _clickService;
        private readonly IPopUpCreateService _popUpCreateService;

        private Transform _popUpRoot;
        public Button ClickButton;

        public ClickerPresenter(IClickerModel clickerModel,
            IUpgradesMoneyModel upgradesMoneyModel,
            IClickService clickService,
            IPopUpCreateService popUpCreateService)
        {
            _clickerModel = clickerModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _clickService = clickService;
            _popUpCreateService = popUpCreateService;
        }

        public void Constructor(ClickerView clickerView)
        {
            _clikerView = clickerView;
            _popUpRoot = clickerView._popUpRoot;
        }
        
        public void Start()
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


        public void Dispose()
        {
            ClickButton.onClick.RemoveAllListeners();
            _clickerModel.OnValueChanged -= UpdateUi;
        }
    }
}