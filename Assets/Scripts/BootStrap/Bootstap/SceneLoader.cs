using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BootStrap
{
    public class SceneLoader
    {
        public async UniTask Load(string name, Action onLoaded = null)
        { 
            await LoadScene(name, onLoaded);
        }

        private async UniTask LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                return;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            
            await waitNextScene;

            if (waitNextScene.isDone)
                onLoaded?.Invoke();
        }
    }
}