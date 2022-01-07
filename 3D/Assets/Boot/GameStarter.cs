using Assets.Resources;
using UnityEngine;

namespace Assets.Boot
{
    public class GameStarter : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            DontDestroyOnLoad(this);
        }
    }
}