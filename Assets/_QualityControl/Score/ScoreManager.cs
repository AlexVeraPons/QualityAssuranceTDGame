using System;
using UnityEngine;

namespace TowerDefenseGame.Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private int _initialScore;
        public static  Action<int> OnScoreChanged;
        private ScoreKeeper _scoreKeeper;
        private void Awake()
        {
            _scoreKeeper = new ScoreKeeper(_initialScore);
        }
        private void Start() {
            OnScoreChanged?.Invoke(_scoreKeeper.Score);
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
