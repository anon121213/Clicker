using UnityEngine;

namespace BootStrap
{
    public class CreateAssetService : ICreateAsset
    {
        public GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}