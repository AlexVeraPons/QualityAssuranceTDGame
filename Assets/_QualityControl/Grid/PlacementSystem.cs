using System;
using UnityEngine;
namespace TowerDefenseGame.GridLayout
{
    public class PlacementSystem : MonoBehaviour, IPlace
    {
        public Action OnObjectPlaced;

        [Header("References")]
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private GameObject _selectionIndicatorObject;
        [SerializeField] private MouseInputManager _inputManager;

        private Grid _grid;
        private GridConfig _gridConfig;
        private Vector3 _mousePosition;
        private const float _yOffset = 0.08f;

        private GameObject _objectToPlace;


        private void Awake()
        {
            _grid = _gridManager.Grid;
            _gridConfig = _gridManager.GridConfig;
        }

        private void OnEnable() {
            _inputManager.OnLeftMouseButtonDown += PlacementSqeuence;
        }

        private void OnDisable() {
            _inputManager.OnLeftMouseButtonDown -= PlacementSqeuence;
        }

        private void Update()
        {
            UpdateSelectionIndicator();

            if(_objectToPlace != null) {
                UpdateObjectToPlace();
            }
        }

        /// <summary>
        /// Starts the placement of the given game object
        /// </summary>
        public void StartPlacing(GameObject gameObjectToPlace)
        {
            _objectToPlace = Instantiate(gameObjectToPlace, Vector3.zero, Quaternion.identity);
        }

        private void UpdateObjectToPlace()
        {
            Debug.Log("Update object to place");
            Vector3Int cellPosition = CellPositionFromMousePosition();
            Vector3 cellTransform = _grid.GetCellCenterWorld(cellPosition);
            cellTransform.y += _yOffset*2;

            _objectToPlace.transform.position = cellTransform;
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

        private bool TryPlace()
        {
            if (_inputManager.IsMouseOverLayer() == false) return false;
            Vector2Int cellPosition = (Vector2Int)CellPositionFromMousePosition();

            if(_gridManager.TryGetCellInfo(cellPosition, out CellInfo cellInfo))
            {
                if(cellInfo.IsOccupied == true)
                {
                    return false;
                }
            }

            CellInfo newCellInfo = new CellInfo();
            newCellInfo.Position = cellPosition;
            newCellInfo.IsOccupied = true;
            newCellInfo.OccupyingObject = _objectToPlace;

            _objectToPlace.GetComponent<IPlacebleObject>().Place(_grid.GetCellCenterWorld((Vector3Int)cellPosition));
            _objectToPlace = null;

            _gridManager.UpdateCellInfo(newCellInfo);

            return true;
        } 

        
        private void PlacementSqeuence()
        {
            if(_objectToPlace == null) return;

            if(TryPlace() == true)
            {
                OnObjectPlaced?.Invoke();
            }
        }

    }
}
