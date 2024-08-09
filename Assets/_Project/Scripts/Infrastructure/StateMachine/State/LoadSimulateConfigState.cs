using _Project.Scripts.Data;
using _Project.Scripts.Services.SaveLoadService;
using _Project.Scripts.Services.SimulateCurrentDataService;
using _Project.Scripts.Services.StaticDataService;
using Zenject;

namespace _Project.Scripts.Infrastructure.StateMachine.State
{
    public class LoadSimulateConfigState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStaticDataService _staticDataService;
        private readonly ISimulateCurrentDataService _simulateData;

        public LoadSimulateConfigState(IGameStateMachine gameStateMachine, ISimulateCurrentDataService simulateData,
            ISaveLoadService saveLoadService, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;
            _simulateData = simulateData;
        }

        public void Enter()
        {
            var progress = LoadConfigOrInitNew();

            _gameStateMachine.Enter<GameMenuState>();
        }

        public void Exit()
        {
        }

        private CurrentData LoadConfigOrInitNew()
        {
            _simulateData.SimulateData =
                _saveLoadService.LoadConfig()
                ?? NewConfig();
            return _simulateData.SimulateData;
        }

        private CurrentData NewConfig()
        {
            var config = new CurrentData();
            return config;
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadSimulateConfigState>
        {
        }
    }
}