using System.Threading.Tasks;
using PopUp.Main;
using UnityEngine;

namespace PopUp.Factory
{
    public interface IPopUpFactory
    {
        Task<PopUpCountChanger> Create(Vector2 position, Transform root, Quaternion rotation);
    }
}