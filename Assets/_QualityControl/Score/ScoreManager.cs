using System;
using UnityEngine;

namespace TowerDefenseGame.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public Action<int> OnScoreChanged;
        private ScoreKeeper _scoreKeeper;
        private void Awake()
        {
            _scoreKeeper = new ScoreKeeper();
        }

        private void OnEnable()
        {
            Goal.OnGoalReached += AddScore;
        }

        private void AddScore(int value)
        {
            _scoreKeeper.AddScore(value);
            OnScoreChanged?.Invoke(_scoreKeeper.Score);
        }

        private void OnDisable()
        {
            Goal.OnGoalReached -= AddScore;
        }
    }
}
