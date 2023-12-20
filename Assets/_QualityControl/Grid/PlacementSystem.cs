using System;
using UnityEngine;
namespace TowerDefenseGame.GridLayout
{
    public class PlacementSystem : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private GameObject _selectionIndicatorObject;
        [SerializeField] private MouseInputManager _inputManager;

        private Grid _grid;
        private GridConfig _gridConfig;
        private Vector3 _mousePosition;
        private const float _yOffset = 0.08f;
        private void Awake()
        {
            _grid = _gridManager.Grid;
            _gridConfig = _gridManager.GridConfig;
        }

        private void OnEnable() {
            _inputManager.OnLeftMouseButtonDown += TryPlace;
        }

        private void OnDisable() {
            _inputManager.OnLeftMouseButtonDown -= TryPlace;
        }

        private void Update()
        {
            UpdateSelectionIndicator();
        }

        private void UpdateSelectionIndicator()
        {
            Vector3Int cellPosition = CellPositionFromMousePosition();
            Vector3 cellTransform = _grid.GetCellCenterWorld(cellPosition);
            cellTransform.y += _yOffset;

            _selectionIndicatorObject.transform.position = cellTransform;
        }

        private Vector3Int CellPositionFromMousePosition()
        {
            _mousePosition = _inputManager.GetMousePosition();

            Vector3Int cellPosition = _grid.WorldToCell(_mousePosition);
            return cellPosition;
        }

        private void TryPlace()
        {
            if (_inputManager.IsMouseOverLayer() == false) return;
            Vector2Int cellPosition = (Vector2Int)CellPositionFromMousePosition();

            if(_gridManager.TryGetCellInfo(cellPosition, out CellInfo cellInfo))
            {
                if(cellInfo.IsOccupied == true)
                {
                    Debug.Log("Cell is occupied");
                    return;
                }
            }

            CellInfo newCellInfo = new CellInfo();
            newCellInfo.Position = cellPosition;
            newCellInfo.IsOccupied = true;
            newCellInfo.OccupyingObject = null;

            _gridManager.UpdateCellInfo(newCellInfo);
        } 
    }
}
