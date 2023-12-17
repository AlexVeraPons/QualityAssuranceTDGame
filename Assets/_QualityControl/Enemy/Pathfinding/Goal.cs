using UnityEngine;
using TowerDefenseGame.Pathfinding;
using System;

namespace TowerDefenseGame
{
    public class Goal : MonoBehaviour, IPathfindingGoal, IGoal
    {
        public static Action<int> OnGoalReached;

        public void ReachedGoal(int value)
        {
            Debug.Log($"Goal: {value}");
            OnGoalReached?.Invoke(value);
        }
    }
}
