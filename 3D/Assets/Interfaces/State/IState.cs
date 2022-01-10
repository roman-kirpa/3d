namespace Interfaces.State
{
    public interface IState : IExitableState
    {
        void EnterToState();
    }
}