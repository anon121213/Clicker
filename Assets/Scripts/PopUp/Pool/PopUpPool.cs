using Unity.Mathematics;
using UnityEngine;

namespace PopUp.Pool
{
    public class PopUpPool : ClickPopUpPool<PopUpCountChanger>
    {
        public PopUpCountChanger prefab;
        public Vector2 position;
        public Transform perentTransform;

        public void Click()
        {
            Create();
        }
        
        public override PopUpCountChanger Create()
        {
            return Object.Instantiate(prefab, position, quaternion.identity, perentTransform);
        }
    }
}