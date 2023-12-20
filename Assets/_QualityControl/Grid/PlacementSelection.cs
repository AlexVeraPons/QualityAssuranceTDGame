using System;
using UnityEngine;
namespace TowerDefenseGame.GridLayout
{
    public class GridSelection : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private GameObject _selectedObject;
        [SerializeField] private MouseInputManager _inputManager;

        private Grid _grid;
        private GridConfig _gridConfig;

        private void Awake()
        {
            _grid = _gridManager.Grid;
            _gridConfig = _gridManager.GridConfig;
        }
        private void Update()
        {
            Vector3 mousePosition = _inputManager.GetMousePosition();

            Vector3Int cellPosition = _grid.WorldToCell(mousePosition);
            Vector3 cellTransform = _grid.GetCellCenterWorld(cellPosition);
            cellTransform.y += 0.08f;

            _selectedObject.transform.position = cellTransform;
        }
    }
}
