using PopUp.Main;
using UnityEngine;

namespace PopUp.Factory
{
    public interface IPopUpFactory
    {
        PopUpCountChanger Create(Vector2 position, Transform root, Quaternion rotation);
    }
}