using UnityEngine;

namespace BootStrap
{
    public interface ICreateAsset
    {
        GameObject Instantiate(string path);
    }
}