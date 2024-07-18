using BootStrap.Data.DataServices;
using BootStrap.FSM;
using BootStrap.FSM.States;
using UnityEngine;
using VContainer;

namespace BootStrap.Bootstap
{
    public class MainBootstrapper: MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;
        private GameStateMachine _gameStateMachine;
        private CreateHudState _createHudState;

        [Inject]
        private void Inject(CreateHudState createHudState,
            ISaveLoadService saveLoadService,
            GameStateMachine gameStateMachine)
        {
            _createHudState = createHudState;
            _saveLoadService = saveLoadService;
            _gameStateMachine = gameStateMachine;
        }

        public void Start()
        {
            AddStates(_gameStateMachine);
            _gameStateMachine.Enter<CreateHudState>();
        }

        public void OnApplicationQuit()
        {
            _saveLoadService.SaveProgress();
        }

        private void AddStates(GameStateMachine gameStateMachine)
        {
            gameStateMachine.AddState(typeof(CreateHudState), _createHudState);
        }
    }
}