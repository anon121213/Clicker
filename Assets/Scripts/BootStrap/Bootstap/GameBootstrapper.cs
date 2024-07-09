﻿using BootStrap.Data.DataService;
using BootStrap.FSM;
using BootStrap.FSM.States;
using BootStrap.GameFabric;
using UnityEngine;
using VContainer;

namespace BootStrap.Bootstap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private IProgressUsersService _progressUsersService;

        [Inject]
        private void Inject(IGameFactory gameFactory, IPersistentProgressService progressService, ISaveLoadService saveLoadService, IProgressUsersService progressUsersService)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _progressUsersService = progressUsersService;
        }
        
        private void Awake()
        {
            SceneLoader sceneLoader = new SceneLoader();
            GameStateMachine gameStateMachine = new GameStateMachine();
            
            AddStates(gameStateMachine, sceneLoader);
            gameStateMachine.Enter<BootstrapState>();
        }

        private void OnApplicationQuit()
        {
            _saveLoadService.SaveProgress();
        }

        private void AddStates(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            gameStateMachine.AddState(typeof(BootstrapState), new BootstrapState(gameStateMachine, sceneLoader));
            gameStateMachine.AddState(typeof(LoadProgressState), new LoadProgressState(gameStateMachine, _progressService, _saveLoadService));
            gameStateMachine.AddState(typeof(LoadLevelState), new LoadLevelState(sceneLoader, _gameFactory, _progressService, _progressUsersService));
        }
    }
}