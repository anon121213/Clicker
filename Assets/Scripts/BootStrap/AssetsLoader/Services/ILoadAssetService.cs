using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BootStrap.AssetsLoader.Services
{
    public interface ILoadAssetService
    {
        UniTask<TObject> GetAsset<TObject>(AssetReference path) where TObject : Object;
    }
}