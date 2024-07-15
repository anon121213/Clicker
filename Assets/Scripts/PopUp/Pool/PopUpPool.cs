using BootStrap.Data.SavesServices;
using BootStrap.Data.StaticData;
using Cysharp.Threading.Tasks;
using PopUp.Main;
using UnityEngine;
using VContainer;

namespace PopUp.Pool
{
    public class PopUpPool : ObjectPool<PopUpCountChanger>
    {
        [Inject] private IStaticDataProvider _dataProvider;

        private GameObject _popUp;
        
        public async UniTask Warmup()
        {
            if (!_popUp)
                _popUp = await _dataProvider.AssetsReferences.PopUp.LoadAssetAsync<GameObject>();
            
            Prefab = _popUp.GetComponent<PopUpCountChanger>();
        }
    }
}