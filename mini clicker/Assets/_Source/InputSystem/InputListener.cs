using Core;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private Game _game;

        public void Construct(Game game)
        {
            _game = game;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _game.OnApplicationExit();
            }
        }
    }
}