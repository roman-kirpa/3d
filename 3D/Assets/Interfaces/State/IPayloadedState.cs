namespace Interfaces.State
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void EnterToState(TPayload payload);
    }
}