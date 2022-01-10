using BaseCode;
using Interfaces;

namespace Resources
{
    public class Game
    {
        public static IInputService InputService;
        public StateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new StateMachine(new SceneLoader(coroutineRunner));
        }
    }
}
