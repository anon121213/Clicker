using BootStrap.AssetsLoader;
using BootStrap.AssetsLoader.Services;
using Cysharp.Threading.Tasks;
using PopUp.Main;
using UnityEngine;
using VContainer;

namespace PopUp.Pool
{
    public class PopUpPool : ObjectPool<PopUpCountChanger>
    {
        [Inject] private ILoadAssetService _loadAssetService;
        
        public async UniTask Warmup()
        {
            GameObject prefab = await _loadAssetService.GetAsset<GameObject>(PathConstants.PopUpPath);
            Prefab = prefab.GetComponent<PopUpCountChanger>();
        }
    }
}