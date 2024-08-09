using System;
using System.Collections.Generic;
using _Project.Scripts.Infrastructure.StateMachine.State;

namespace _Project.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<System.Type, IExitableState> registeredStates;
        private IExitableState currentState;

        public GameStateMachine(
            BootstrapState.Factory bootstrapStateFactory,
            LoadSimulateConfigState.Factory loadGameSaveStateFactory,
            LoadLevelState.Factory loadLevelStateFactory, GameMenuState.Factory gameMenuStateFactory,
            GameLoopState.Factory gameLoopStateFactory)
        {
            registeredStates = new Dictionary<Type, IExitableState>();
            
            RegisterState(bootstrapStateFactory.Create(this));
            RegisterState(loadGameSaveStateFactory.Create(this));
            RegisterState(loadLevelStateFactory.Create(this));
            RegisterState(gameLoopStateFactory.Create(this));
            RegisterState(gameMenuStateFactory.Create(this));
        }

        private void RegisterState<TState>(TState state) where TState : IExitableState =>
            registeredStates.Add(typeof(TState), state);

        public void Enter<TState>() where TState : class, IState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            currentState?.Exit();
      
            TState state = GetState<TState>();
            currentState = state;
      
            return state;
        }
    
        private TState GetState<TState>() where TState : class, IExitableState => 
            registeredStates[typeof(TState)] as TState;
    }
}