using System;
using BootStrap.GameFabric;
using BootStrap.Services;
using Data;
using UnityEngine;

namespace BootStrap.FSM
{
    public class LoadLevelState: IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly PlayerProgress _progress;

        public LoadLevelState(SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string name)
        {
            _gameFactory.Cleanup();
            _sceneLoader.Load(name, OnLoaded);
            InformProgressRiders();
        }

        private void OnLoaded()
        {
            _gameFactory.CreateHud();
        }

        private void InformProgressRiders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_progressService.Progress);
            }
        }

        public void Exit()
        {
        }
    }
}