using System;
using UnityEngine;

namespace TowerDefenseGame.Spawner
{
    public class Spawner : MonoBehaviour
    {
        // variables
        [SerializeField] private SpawnerStats _spawnerStats;
        private IGameObjectFactory _gameObjectFactory;
        private Timer _timerForSpawner;

        public void SetSpawnerStats(SpawnerStats spawnerStats)
        {
            _spawnerStats = spawnerStats;
        }

        public void StopSpawning()
        {
            _timerForSpawner.StopTimer();
        }

        public void StartSpawning()
        {
            _timerForSpawner.StartTimer();
        }

        private void OnEnable()
        {
            _timerForSpawner.OnTimerEnd += SpawnTimerEnded;
        }

        private void OnDisable()
        {
            _timerForSpawner.OnTimerEnd -= SpawnTimerEnded;
        }

        private void Awake() {
            _timerForSpawner = new Timer(_spawnerStats.spawnRate, true, false);
            _gameObjectFactory = GetComponent<IGameObjectFactory>();
            if (_gameObjectFactory == null)
            {
                Debug.LogError("Spawner: Awake(): _gameObjectFactory is null");
            }
        }

        private void Start() {
            _timerForSpawner.StartTimer(); // only for testing
        }

        private void SpawnTimerEnded()
        {
            Spawn();
        }

        private void Spawn()
        {
            GameObject oobj = Instantiate(_gameObjectFactory.GetGameObject(), transform.position, Quaternion.identity);
            oobj.transform.SetParent(transform);
        }

        private void Update() {
            _timerForSpawner.UpdateTimer();
        }
    }
}
