namespace _Project.Scripts.Infrastructure.StateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}