using PopUp.Factory;
using PopUp.Main;
using Settings;
using Unity.Mathematics;
using UnityEngine;
using UpgradeSystem;

namespace ClickSystem
{
    public class ClickerPresenter
    {
        private readonly AudioClip _clickSound;
        private readonly Transform _popUpRoot;
        private readonly ClickerModel _clickerModel;
        private readonly ClickerView _clikerView;
        private readonly UpgradesModel _upgradesModel;
        private readonly IPopUpFactory _popUpFactory;

        public ClickerPresenter(ClickerModel clickerModel, ClickerView clikerView, UpgradesModel upgradesModel, IPopUpFactory popUpFactory)
        {
            _clikerView = clikerView;
            _clickerModel = clickerModel;
            _upgradesModel = upgradesModel;
            _popUpFactory = popUpFactory;
            _clickSound = clikerView._clickSound;
            _popUpRoot = clikerView._popUpRoot;
            Start();
        }
        
        private void Start()
        {
            Debug.Log(_clikerView);
            _clikerView.UpdateClickCount(_clickerModel.GetMoneyCount());
            _clikerView._clickButton.onClick.AddListener(Click);
        }
        
        private void Click()
        {
            PlaySFX.instance.PlayMusic(_clickSound);
            _clickerModel.IncrementMoneyCount(_upgradesModel.GetClickPrice());
            _clikerView.UpdateClickCount(_clickerModel.GetMoneyCount());
        
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                var clickPosition = touch.position;
                PopUpCountChanger popUp = _popUpFactory.Create(clickPosition, _popUpRoot, quaternion.identity);
                popUp.Enable();
            }
        }
    }
}