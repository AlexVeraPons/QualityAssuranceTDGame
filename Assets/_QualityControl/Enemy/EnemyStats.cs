using UnityEngine;

namespace TowerDefenseGame.Enemy
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "TowerDefenseGame/EnemyStats", order = 0)]
    public class EnemyStats : ScriptableObject 
    {
        public float health;
        public float value;   
    }
}
