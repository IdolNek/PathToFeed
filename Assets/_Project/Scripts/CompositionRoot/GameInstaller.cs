using _Project.Scripts.Infrastructure;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.StateMachine;
using _Project.Scripts.Services.SaveLoadService;
using _Project.Scripts.Services.SimulateCurrentDataService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.UI.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameBootstraperFactory();

            BindCoroutineRunner();

            BindSceneLoader();

            BindLoadingCurtain();

            BindGameStateMachine();

            BindStaticDataService();

            BindGameFactory();
        
            BindUIFactory();

            BindSimulateDataService();

            BindSaveLoadService();
        }

        private void BindStaticDataService() => 
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

        private void BindGameBootstraperFactory()
        {
            Container
                .BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.GameBootstraper);
        }
        
        private void BindSaveLoadService()
        {
            Container
                .BindInterfacesAndSelfTo<SaveLoadService>()
                .AsSingle();
        }

        private void BindSimulateDataService()
        {
            Container
                .BindInterfacesAndSelfTo<SimulateCurrentDataService>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container
                .Bind<IGameFactory>()
                .FromSubContainerResolve()
                .ByInstaller<GameFactoryInstaller>()
                .AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .FromSubContainerResolve()
                .ByInstaller<UIFactoryInstaller>()
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CoroutineRunnerPath)
                .AsSingle();
        }

        private void BindSceneLoader() => 
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

        private void BindLoadingCurtain() => 
            Container.Bind<ILoadingCurtain>().To<LoadingCurtain>().FromComponentInNewPrefabResource(InfrastructureAssetPath.CurtainPath).AsSingle();

        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
            Debug.Log("Bind IGameStateMachine");
        }
    }
}