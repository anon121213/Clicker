using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BootStrap.Assets
{
    public class LoadAssetService : ILoadAsset
    {
        private Dictionary<string, Object> _assets = new();

        public TObject GetAsset<TObject>(string name) where TObject : Object
        {
            if (_assets.ContainsKey(name))
            {
                return _assets[name] as TObject;
            }
            else
            {
                Debug.LogError("This key was not found");
                return null;
            }
        }

        public async UniTask LoadAssets()
        {
            await UniTask.WhenAll(
                LoadAsset(PathConstants.HudPath),
                LoadAsset(PathConstants.PopUpPath)
                );
        }

        private async UniTask LoadAsset(string path)
        {
            UniTaskCompletionSource<bool> utcs = new UniTaskCompletionSource<bool>();
            AsyncOperationHandle<Object> handle = Addressables.LoadAssetAsync<Object>(path);
            
            handle.Completed += (AsyncOperationHandle<Object> op) =>
            {
                OnPrefabLoaded(op);
                utcs.TrySetResult(true);
            };
            
            await utcs.Task;
        }

        private void OnPrefabLoaded(AsyncOperationHandle<Object> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                if (!_assets.ContainsValue(handle.Result))
                    _assets.Add(handle.Result.name, handle.Result);
            }
            else
            {
                Debug.LogError("Не удалось загрузить префаб по пути: ");
            }
        }
    }
}