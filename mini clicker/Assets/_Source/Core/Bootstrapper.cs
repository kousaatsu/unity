using ClickSystem;
using InputSystem;
using ScoreSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private ClickableComponent clickableComponent;
        [SerializeField] private ScoreView scoreView;
        private Game _game;
        private Score _score;

        private void Awake()
        {
            Init();
            StartGame();
        }
        private void Init()
        {
            _score = new Score();
            _game = new Game(_score);
            inputListener.Construct(_game);
            clickableComponent.Construct(_score);
            scoreView.Construct(_score);
        }

        private void StartGame()
        {
            _game.OnApplicationStart();
        }
    }
}