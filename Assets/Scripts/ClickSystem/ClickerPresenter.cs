using System;
using BootStrap.Data;
using PopUp.Factory;
using PopUp.Main;
using TMPro;
using Unity.Mathematics;
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
        private readonly IPopUpFactory _popUpFactory;

        public Button ClickButton;

        public ClickerPresenter(IClickerModel clickerModel, ClickerView clickerView, IUpgradesMoneyModel upgradesMoneyModel, IPopUpFactory popUpFactory)
        {
            _clikerView = clickerView;
            _clickerModel = clickerModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _popUpFactory = popUpFactory;
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
        
        private async void Click()
        {
            _clickerModel.AddMoney(_upgradesMoneyModel.ClickPrice);
        
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 clickPosition = touch.position;
                PopUpCountChanger popUp = await _popUpFactory.Create(clickPosition, _popUpRoot, quaternion.identity);
                SetToDefault(popUp, clickPosition);
                popUp.Enable(_upgradesMoneyModel.ClickPrice);
            }
        }

        private void SetToDefault(PopUpCountChanger popUp, Vector2 clickPosition)
        {
            popUp.transform.position = clickPosition;
            Color color = popUp.GetComponent<TextMeshProUGUI>().color;
            color.a = 1;
            popUp.GetComponent<TextMeshProUGUI>().color = color;
        }

        private void UpdateUi() =>
            _clikerView.UpdateClickCount(_clickerModel.Money);
        
        public void Disable()
        {
            Debug.Log("a");
            _clickerModel.OnValueChanged -= UpdateUi;
        }
    }
}