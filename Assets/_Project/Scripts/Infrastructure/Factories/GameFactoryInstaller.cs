using _Project.Scripts.Simulation;
using _Project.Scripts.UI.HUD;
using Zenject;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class GameFactoryInstaller : Installer<GameFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<HUDRoot, HUDRoot.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.HUDRoot);

            Container.BindFactory<SimulationManager, SimulationManager.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.SimulationManager);

            Container.Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }
    }
}