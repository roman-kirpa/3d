using Assets.Interfaces;
using Assets.Services.Input;
using UnityEngine;

namespace Assets.Resources
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            InitializeInputServise();
        }

        private void InitializeInputServise()
        {
            //InputService = Application.isEditor ? (IInputService)new UnityInputService() : (IInputService)new MobileInputService();
            InputService = new MobileInputService();
        }
    }
}
