using UnityEngine;
using TowerDefenseGame.Pathfinding;
using System;

namespace TowerDefenseGame
{
    public class Goal : MonoBehaviour, IPathfindingGoal, IGoal
    {
        public static Action<int> OnGoalReached;
        public static Action<int> OnAddScore;

        public void ReachedGoal(int value)
        {
            Debug.Log($"Goal: {value}");
            OnAddScore?.Invoke(value);
            OnGoalReached?.Invoke(value);
        }
    }
}
