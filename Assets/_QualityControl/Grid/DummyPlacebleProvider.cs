using UnityEngine;

namespace TowerDefenseGame.GridLayout
{
    [RequireComponent(typeof(PlacementSystem))]
    public class DummyPlacebleProvider : MonoBehaviour
    {
        private PlacementSystem _placementSystem;
        [SerializeField] private GameObject _dummyObject;
        private void Awake() {
            _placementSystem = new PlacementSystem();
        }
        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                _placementSystem.StartPlacing(_dummyObject);
            }
        }
    }
}
