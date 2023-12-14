using UnityEngine;

namespace TowerDefenseGame.Spawner
{
    [CreateAssetMenu(fileName = "SpawnerStats", menuName = "TowerDefenseGame/SpawnerStats", order = 0)]
    public class SpawnerStats : ScriptableObject
    {
        public float spawnRate;
    }
}
