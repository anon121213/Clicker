using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace BootStrap.AssetsLoader.Services
{
    public interface ILoadAssetService
    {
        UniTask<TObject> GetAsset<TObject>(AssetReference path) where TObject : Object;
    }
}