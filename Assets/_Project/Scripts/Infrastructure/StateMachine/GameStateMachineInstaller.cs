using _Project.Scripts.Infrastructure.StateMachine.State;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadSimulateConfigState, LoadSimulateConfigState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelState.Factory>();
            Container.BindFactory<IGameStateMachine, GameMenuState, GameMenuState.Factory>();
            Container.BindFactory<IGameStateMachine, GameLoopState, GameLoopState.Factory>();
            

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        
            Debug.Log("GameStateMachineInstaller");
        }
    }
}