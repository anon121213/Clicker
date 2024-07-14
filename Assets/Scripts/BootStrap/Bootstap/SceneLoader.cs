using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace BootStrap.Bootstap
{
    public class SceneLoader
    {
        public async UniTask Load(AssetReference nextScene, Action onLoaded = null)
        {
            await LoadScene(nextScene, onLoaded);
        }

        private async UniTask LoadScene(AssetReference nextScene, Action onLoaded = null)
        {
            AsyncOperationHandle<SceneInstance> waitNextScene = nextScene.LoadSceneAsync();
            
            await waitNextScene;

            if (waitNextScene.IsDone)
                onLoaded?.Invoke();
        }
    }
}