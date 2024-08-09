using _Project.Scripts.Infrastructure;
using _Project.Scripts.UI.Interface;
using Zenject;

namespace _Project.Scripts.UI.Factories
{
    public class UIFactoryInstaller : Installer<UIFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<InterfaceRoot, InterfaceRoot.Factory>().FromComponentInNewPrefabResource(InfrastructureAssetPath.InterfaceRoot);
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }
    }
}