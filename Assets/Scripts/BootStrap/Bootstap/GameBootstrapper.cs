﻿using System;
using BootStrap.Data.DataServices;
using BootStrap.FSM;
using BootStrap.FSM.States;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace BootStrap.Bootstap
{
    public class GameBootstrapper : MonoBehaviour, IInitializable, IDisposable
    {
        private ISaveLoadService _saveLoadService;
        private BootstrapState _bootstrapState;
        private LoadProgressState _loadProgressState;
        private LoadLevelState _loadLevelState;
        private GameStateMachine _gameStateMachine;
        
        [Inject]
        private void Inject(BootstrapState bootstrapState,
            LoadProgressState loadProgressState,
            LoadLevelState loadLevelState,
            ISaveLoadService saveLoadService,
            GameStateMachine gameStateMachine)
        {
            _bootstrapState = bootstrapState;
            _loadProgressState = loadProgressState;
            _loadLevelState = loadLevelState;
            _saveLoadService = saveLoadService;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            AddStates(_gameStateMachine);
            _gameStateMachine.Enter<BootstrapState>();
        }

        private void OnApplicationQuit() =>
            _saveLoadService.SaveProgress();

        public void Initialize()
        {
            AddStates(_gameStateMachine);
            _gameStateMachine.Enter<BootstrapState>();
        }

        public void Dispose() =>
            _saveLoadService.SaveProgress();

        private void AddStates(GameStateMachine gameStateMachine)
        {
            gameStateMachine.AddState(typeof(BootstrapState), _bootstrapState);
            gameStateMachine.AddState(typeof(LoadProgressState), _loadProgressState);
            gameStateMachine.AddState(typeof(LoadLevelState), _loadLevelState);
        }
    }
}