
using UnityEngine;

namespace TowerDefenseGame
{
    public class DummyObjectFactory :MonoBehaviour, IGameObjectFactory
    {
        [SerializeField] private GameObject _dummyObject;
        public GameObject GetGameObject()
        {
            return _dummyObject;
        }
    }
}
