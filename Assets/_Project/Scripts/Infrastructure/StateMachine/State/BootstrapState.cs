using _Project.Scripts.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.StateMachine.State
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine,
            IStaticDataService staticDataService)
        {
            Debug.Log("BootstrapState constructor");
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            Debug.Log("BootstrapState Enter");
            
            InitServices();
            _gameStateMachine.Enter<LoadSimulateConfigState>();
        }

        private async void InitServices()
        {
            _staticDataService.Initialize();
        }

        public void Exit()
        {
            Debug.Log("BootstrapState Exit");
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}