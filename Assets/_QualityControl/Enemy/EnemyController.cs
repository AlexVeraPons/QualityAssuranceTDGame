using System;
using UnityEngine;

namespace TowerDefenseGame.Enemy
{
    [RequireComponent(typeof(Collider))]
    public class EnemyController : MonoBehaviour , ITakeDamage
    {
        [SerializeField]
        [Tooltip("The penalty percentage applied to the value if the enemy reached the end undefeated.")]
        private float _penaltyPercentage = 0.5f;
        public Action OnEndReached;
        private bool _isDefeated;
        [SerializeField] private EnemyStats _stats;

        private void OnEnable()
        {
            _isDefeated = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<IGoal>() != null)
            {
                IGoal goal = other.gameObject.GetComponent<IGoal>();

                if (_isDefeated)
                {
                    goal.ReachedGoal(_stats.value);
                }
                else
                {
                    goal.ReachedGoal(Mathf.RoundToInt(-(_stats.value * _penaltyPercentage)));
                }

                ReachedEnd();
            }
        }

        private void ReachedEnd()
        {
            OnEndReached?.Invoke();
            Destroy(gameObject);
            return;
        }

        public void TakeDamage(float damage)
        {
            _stats.health -= damage;
            if (_stats.health <= 0)
            {
                Defeated();
            }
        }

        private void Defeated()
        {
            if (_isDefeated) { return; }
            _isDefeated = true;
        }
    }
}
