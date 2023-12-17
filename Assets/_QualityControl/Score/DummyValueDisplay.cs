using TowerDefenseGame.Enemy;
using UnityEngine;

namespace TowerDefenseGame
{
    public class DummyValueDisplay : MonoBehaviour
    {
        private void OnEnable() {
            Goal.OnGoalReached += UpdateValue;
        }

        private void OnDisable() {
            Goal.OnGoalReached -= UpdateValue;
        }
        public void UpdateValue(int value)
        {
            Debug.Log($"DummyValueDisplay: {value}");
        }
    }
}
