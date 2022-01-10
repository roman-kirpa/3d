using BaseCode.States;
using Interfaces.State;
using System;
using System.Collections.Generic;

namespace BaseCode
{
    public class StateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        public IExitableState activeExitableState;
        
        public StateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState> 
            {
                { typeof(BootstrapState), new BootstrapState(this, sceneLoader) },
                { typeof(LevelState), new LevelState(this, sceneLoader) },
            };
        }

        public void EnterState<TState>() where TState : class, IState
        {
            activeExitableState?.ExitFromState();
            IState exitableState = _states[typeof(TState)] as TState;
            exitableState.EnterToState();
        }

        public void EnterState<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            activeExitableState?.ExitFromState();
            IPayloadedState<TPayload> exitableState = _states[typeof(TState)] as TState;
            exitableState.EnterToState(payload);
        }
    }
}
