using UnityEngine;
using TowerDefenseGame.Pathfinding;
using System;

namespace TowerDefenseGame.Enemy
{
    public class Goal : MonoBehaviour, IPathfindingGoal, IGoal
    {
        public Action<float> OnReachedGoal;
        public void ReachedGoal(float value)
        {
            OnReachedGoal?.Invoke(value);
        }
    }
}
