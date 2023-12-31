using System;

namespace TowerDefenseGame.Score
{
    public class ScoreKeeper 
    {
        public Action OnScoreChanged;
        public int Score { get; private set; }

        public void AddScore(int value)
        {
            if(value == 0) {return;}

            Score += value;
            OnScoreChanged?.Invoke();
        }
    }
}
