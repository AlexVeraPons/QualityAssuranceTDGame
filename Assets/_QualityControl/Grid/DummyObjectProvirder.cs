using UnityEngine;

namespace TowerDefenseGame.GridLayout
{
    public class DummyObjectProvirder : MonoBehaviour
    {
        [SerializeField] private GameObject _dummyObject;
        [SerializeField] private PlacementSystem _placementSystem;

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                _placementSystem.StartPlacing(_dummyObject);
            }
        }
    }
}
