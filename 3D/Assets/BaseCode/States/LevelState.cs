using System;
using Interfaces.State;

namespace BaseCode.States
{
    public class LevelState : IPayloadedState<string>
    {
        private SceneLoader _sceneLoader;
        private StateMachine _stateMachine;

        public LevelState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
       
        public void EnterToState(string sceneName)
        {
            _sceneLoader.Load(sceneName);
        }

        public void ExitFromState()
        {
            throw new NotImplementedException();
        }

        private void EnterLoadLevel()
        {
            throw new NotImplementedException();
        }
    }
}
