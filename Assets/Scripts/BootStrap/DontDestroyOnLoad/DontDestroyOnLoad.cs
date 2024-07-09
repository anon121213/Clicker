using UnityEngine;

namespace BootStrap.DontDestroyOnLoad
{
    public class DontDestroyOnLoad: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}