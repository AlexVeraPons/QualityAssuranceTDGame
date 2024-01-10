using System;
using UnityEngine.SocialPlatforms.Impl;

namespace TowerDefenseGame.Score
{
    public class ScoreKeeper 
    {
        public Action OnScoreChanged;
        public int Score { get; private set; }

        public ScoreKeeper()
        {
            Score = 0;
        }

        public ScoreKeeper(int score)
        {
            Score = score;
        }

        public void AddScore(int value)
        {
            if(value == 0) {return;}

            Score += value;
            OnScoreChanged?.Invoke();
        }
    }
}
