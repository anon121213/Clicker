using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.Assets
{
    public interface ILoadAsset
    {
        TObject GetAsset<TObject>(string name) where TObject : Object;
        UniTask LoadAsset(string path);
    }
}