using System;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace TowerDefenseGame.Spawner
{
    public class Spawner : MonoBehaviour
    {
        public Action OnSpawned;
        [SerializeField] private bool _spawnOnStart;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private uint _objectsToSpawn;
        private uint _spawnedCount;
        private Timer _timerForSpawner;
        private IGameObjectFactory _gameObjectFactory;

        private void OnEnable()
        {
            if (_spawnInterval > 0)
            {
                _timerForSpawner.OnTimerEnd += SpawnTimerEnded;
            }
            else
            {
                Debug.LogError("Spawner: invalid spawner interval");
            }
        }

        private void OnDisable()
        {
            if (_spawnInterval > 0)
            {
                _timerForSpawner.OnTimerEnd -= SpawnTimerEnded;
            }
        }
        private void Awake()
        {
            _timerForSpawner = new Timer(_spawnInterval, false, false);
            _gameObjectFactory = GetComponent<IGameObjectFactory>();
            if (_gameObjectFactory == null)
            {
                Debug.LogError("Spawner: missing IGameObjectFactory component");
            }
        }
        private void Start()
        {
            if (_spawnOnStart) { StartSpawning(); }
        }
        private void Update() { _timerForSpawner.UpdateTimer(Time.deltaTime); }
        private void LateUpdate() { CheckAmmountSpawned(); }
        public void SetSpawnerSpeed(float spawnerSpeed) { _spawnInterval = spawnerSpeed; }
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
            GameObject spawnedObject = Instantiate(_gameObjectFactory.GetGameObject(), transform.position, transform.rotation);
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
