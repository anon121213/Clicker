using BootStrap.AssetsLoader.Services;
using BootStrap.Data.StaticData;
using Cysharp.Threading.Tasks;
using PopUp.Main;
using UnityEngine;
using VContainer;

namespace PopUp.Pool
{
    public class PopUpPool : ObjectPool<PopUpCountChanger>
    {
        private IStaticDataProvider _dataProvider;
        private ILoadAssetService _loadAsset;

        private GameObject _popUp;
        
        [Inject]
        private void Inject(IStaticDataProvider dataProvider, ILoadAssetService loadAssetService)
        {
            _dataProvider = dataProvider;
            _loadAsset = loadAssetService;
        }
        
        public async UniTask Warmup()
        {
            if (!_popUp)
                _popUp = await _loadAsset.GetAsset<GameObject>(_dataProvider.AssetsReferences.PopUp);
            
            Prefab = _popUp.GetComponent<PopUpCountChanger>();
        }
    }
}