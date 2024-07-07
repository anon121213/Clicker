using BootStrap.GameFabric;
using UnityEngine;

namespace BootStrap.FSM
{
    public class LoadLevelState: IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFabric _gameFabric;

        public LoadLevelState(SceneLoader sceneLoader, IGameFabric gameFabric)
        {
            _sceneLoader = sceneLoader;
            _gameFabric = gameFabric;
        }

        public void Enter(string name)
        {
            _sceneLoader.Load(name, OnLoaded);
        }

        private void OnLoaded()
        {
            _gameFabric.CreateHud();
        }
        
        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}