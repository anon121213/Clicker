using LevelSystem;
using PopUp.Factory;
using PopUp.Main;
using Settings;
using TMPro;
using Unity.Mathematics;
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

        public ClickerPresenter(ClickerModel clickerModel, ClickerView clickerView, UpgradesMoneyModel upgradesMoneyModel, IPopUpFactory popUpFactory)
        {
            _clikerView = clickerView;
            _clickerModel = clickerModel;
            _upgradesMoneyModel = upgradesMoneyModel;
            _popUpFactory = popUpFactory;
            _clickSound = clickerView._clickSound;
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
            PlaySFX.instance.PlayMusic(_clickSound);
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

        public void Disable() =>
            _clickerModel.OnValueChanged -= UpdateUi;
    }
}