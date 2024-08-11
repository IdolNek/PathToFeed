using _Project.Scripts.Simulation;
using _Project.Scripts.UI.HUD;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly HUDRootPresenter.Factory _hudFactory;
        private readonly SimulationManager.Factory _simulationManagerFactory;
        private SimulationManager _simulationManager;

        public GameFactory( HUDRootPresenter.Factory hudFactory, SimulationManager.Factory simulationManagerFactory)
        {
            _simulationManagerFactory = simulationManagerFactory;
            _hudFactory = hudFactory;
        }

        public IHUDRoot CreateHUD()
        {
            HUDRootPresenter hudRootPresenter = _hudFactory.Create();
            hudRootPresenter.Init(_simulationManager);
            return hudRootPresenter;
        }

        public SimulationManager CreateSimulationManager()
        {
            _simulationManager = _simulationManagerFactory.Create();
            _simulationManager.InitializeSimulation();
            return _simulationManager;
        }

        public void Cleanup()
        {
            // Cleanup logic if needed
        }
    }
}