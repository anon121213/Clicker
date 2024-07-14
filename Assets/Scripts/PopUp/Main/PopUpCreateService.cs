using PopUp.Factory;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UpgradeSystem;

namespace PopUp.Main
{
    public interface IPopUpCreateService
    {
        void CreatePopUp(Transform popUpRoot);
    }

    public class PopUpCreateService : IPopUpCreateService
    {
        private readonly IPopUpFactory _popUpFactory;
        private readonly IUpgradesMoneyModel _upgradesMoneyModel;

        public PopUpCreateService(IPopUpFactory popUpFactory, IUpgradesMoneyModel upgradesMoneyModel)
        {
            _popUpFactory = popUpFactory;
            _upgradesMoneyModel = upgradesMoneyModel;
        }
        
        public async void CreatePopUp(Transform popUpRoot)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 clickPosition = touch.position;
            PopUpCountChanger popUp = await _popUpFactory.Create(clickPosition, popUpRoot, quaternion.identity);
            SetToDefault(popUp, clickPosition);
            popUp.Enable(_upgradesMoneyModel.ClickPrice);
        }
        
        private void SetToDefault(PopUpCountChanger popUp, Vector2 clickPosition)
        {
            popUp.transform.position = clickPosition;
            Color color = popUp.GetComponent<TextMeshProUGUI>().color;
            color.a = 1;
            popUp.GetComponent<TextMeshProUGUI>().color = color;
        }
    }
}