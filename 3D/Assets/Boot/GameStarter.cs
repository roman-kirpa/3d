using BaseCode.States;
using Interfaces;
using Resources;
using UnityEngine;

namespace Assets.Boot
{
    public class GameStarter : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.EnterState<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}