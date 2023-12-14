
using UnityEngine;

namespace TowerDefenseGame
{
    public class DummyObjectFactory :MonoBehaviour, IGameObjectFactory
    {
        private GameObject _dummyObject;
        private void Start() {
            _dummyObject = new GameObject("DummyObject");
        }
        public GameObject GetGameObject()
        {
            Debug.Log("DummyObjectFactory: GetGameObject() called");
            return _dummyObject;
        }
    }
}
