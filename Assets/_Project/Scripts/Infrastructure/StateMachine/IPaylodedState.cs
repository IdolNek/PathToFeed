namespace _Project.Scripts.Infrastructure.StateMachine
{
    public interface IPaylodedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}