using System;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace TowerDefenseGame.Spawner
{
    public class Spawner : MonoBehaviour
    {
        public Action OnSpawned;
        [SerializeField] private SpawnerStats _spawnerStats;
        [SerializeField] private uint _objectsToSpawn;
        private uint _spawnedCount;
        private Timer _timerForSpawner;
        private IGameObjectFactory _gameObjectFactory;

        private void OnEnable()
        {
            if (_spawnerStats != null)
            {
                _timerForSpawner.OnTimerEnd += SpawnTimerEnded;
            }
            else
            {
                Debug.LogError("Spawner: missing SpawnerStats component");
            }
        }

        private void OnDisable()
        {
            if (_spawnerStats != null)
            {
                _timerForSpawner.OnTimerEnd -= SpawnTimerEnded;
            }
        }
        private void Awake()
        {
            _timerForSpawner = new Timer(_spawnerStats.spawnRate, false, false);
            _gameObjectFactory = GetComponent<IGameObjectFactory>();
            if (_gameObjectFactory == null)
            {
                Debug.LogError("Spawner: missing IGameObjectFactory component");
            }
        }
        private void Start()
        {
            StartSpawning();
        }
        private void Update() { _timerForSpawner.UpdateTimer(Time.deltaTime); }
        private void LateUpdate() { CheckAmmountSpawned(); }
        public void SetSpawnerStats(SpawnerStats spawnerStats) { _spawnerStats = spawnerStats; }
        public void StopSpawning() { _timerForSpawner.StopTimer(); }
        public void StartSpawning()
        {
            _spawnedCount = 0;
            _timerForSpawner.StartTimer();
        }

        public void StartSpawning(float spawnAmmount)
        {
            _timerForSpawner.StartTimer();
            _objectsToSpawn = (uint)spawnAmmount;
        }

        private void SpawnTimerEnded()
        {
            Spawn();
        }

        private void CheckAmmountSpawned()
        {
            if (_spawnedCount >= _objectsToSpawn)
            {
                _timerForSpawner.StopTimer();

                return;
            }
            _timerForSpawner.StartTimer();
        }

        private void Spawn()
        {

            GameObject spawnedObject = Instantiate(_gameObjectFactory.GetGameObject(), transform.position, Quaternion.identity);
            spawnedObject.transform.SetParent(transform);

            _spawnedCount++;
            OnSpawnedEvent();
        }

        public void OnSpawnedEvent()
        {
            Debug.Log("Spawner: OnSpawnedEvent");
            OnSpawned?.Invoke();
        }

    }
}
