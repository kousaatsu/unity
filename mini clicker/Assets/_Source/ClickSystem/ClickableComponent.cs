using System;
using ScoreSystem;
using UnityEngine;

namespace ClickSystem
{
    public class ClickableComponent : MonoBehaviour
    {
        private Score _score;
        [SerializeField] private int value;
        public void Construct(Score score)
        {
            _score = score;
        }
        private void OnMouseDown()
        {
            _score.AddScore();
        }
    }
}