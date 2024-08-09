using Zenject;

namespace _Project.Scripts.Infrastructure.StateMachine.State
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public GameLoopState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, GameLoopState> { }

    }
}