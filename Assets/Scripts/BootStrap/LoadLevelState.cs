using UnityEngine;

namespace BootStrap
{
    public class LoadLevelState: IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string name)
        {
            _sceneLoader.Load(name, OnLoaded);
        }

        private void OnLoaded()
        {
            Debug.Log(PathConstants.HudPath);
            Debug.Log(Resources.Load<GameObject>(PathConstants.HudPath));
            Instantiate(PathConstants.HudPath);
        }

        private GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}