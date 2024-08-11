using _Project.Scripts.Simulation;
using _Project.Scripts.UI.HUD;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly HUDRoot.Factory _hudFactory;
        private readonly SimulationManager.Factory _simulationManagerFactory;

        public GameFactory( HUDRoot.Factory hudFactory, SimulationManager.Factory simulationManagerFactory)
        {
            _simulationManagerFactory = simulationManagerFactory;
            _hudFactory = hudFactory;
        }

        public IHUDRoot CreateHUD() => _hudFactory.Create();
        public SimulationManager CreateSimulationManager()
        {
            SimulationManager simulationManager = _simulationManagerFactory.Create();
            simulationManager.InitializeSimulation();
            return simulationManager;
        }

        public void Cleanup()
        {
            // Cleanup logic if needed
        }
    }
}