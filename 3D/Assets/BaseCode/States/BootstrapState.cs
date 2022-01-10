using System;
using Interfaces;
using Interfaces.State;
using Resources;
using Services.Input;
using UnityEngine;

namespace BaseCode.States
{
    public class BootstrapState : IState
    {
        private const string Intro = "Intro";
        private StateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void EnterToState()
        {
            InitializeServices();
            _sceneLoader.Load(Intro, EnterLoadLevel);
        }

        public void ExitFromState()
        {
            throw new NotImplementedException();
        }

        private void InitializeServices()
        {
            Game.InputService = Application.isEditor ? (IInputService)new UnityInputService() : (IInputService)new MobileInputService();
        }

        private void EnterLoadLevel()
        {
            _stateMachine.EnterState<LevelState, string>("FirstStage");
        }
    }
}
