using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.AssetsLoader.Services
{
    public interface ILoadAssetService
    {
        TObject GetAsset<TObject>(string name) where TObject : Object;
        UniTask LoadAsset(string path);
    }
}