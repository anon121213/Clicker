using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.AssetsLoader.Services
{
    public interface ILoadAssetService
    {
        UniTask<TObject> GetAsset<TObject>(string path) where TObject : Object;
    }
}