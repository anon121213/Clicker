using PopUp.Main;
using UnityEngine;

namespace PopUp.Pool
{
    public class PopUpPool : ObjectPool<PopUpCountChanger>
    {
        public PopUpCountChanger prefab;

        public void Warmup()
        {
            prefab = Resources.Load<PopUpCountChanger>("/Prefabs/PopUp");
        }
    }
}