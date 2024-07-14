using BootStrap.Data.References;
using Cysharp.Threading.Tasks;
using PopUp.Main;
using UnityEngine;
using VContainer;

namespace PopUp.Pool
{
    public class PopUpPool : ObjectPool<PopUpCountChanger>
    {
        [Inject] private AssetsReferences _assets;

        private GameObject _popUp;
        
        public async UniTask Warmup()
        {
            if (!_popUp)
                _popUp = await _assets.PopUp.LoadAssetAsync<GameObject>();
            
            Prefab = _popUp.GetComponent<PopUpCountChanger>();
        }
    }
}