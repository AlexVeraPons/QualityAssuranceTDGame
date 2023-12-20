using System.Collections.Generic;
using UnityEngine;
namespace TowerDefenseGame.GridLayout
{
    [RequireComponent(typeof(Grid))]
    [ExecuteAlways]
    public class GridManager : MonoBehaviour
    {

        [Header("Grid Config")]
        [SerializeField] private GridConfig _gridConfig;
        [SerializeField] private Grid _grid;

        public Dictionary<Vector2Int, CellInfo> CellInfoDictionary = new();

        private void Awake()
        {
            if (_gridConfig == null) return;
            _grid.cellSize = _gridConfig.CellSize;
            _grid.cellGap = _gridConfig.CellGap;
            _grid.cellSize = _gridConfig.CellSize;
            _grid.cellGap = _gridConfig.CellGap;
        }

        public Grid Grid => _grid;
        public GridConfig GridConfig => _gridConfig;

        public void UpdateCellInfo(CellInfo cellInfo)
        {
            if (CellInfoDictionary.ContainsKey(cellInfo.Position))
            {
                CellInfoDictionary[cellInfo.Position].IsOccupied = cellInfo.IsOccupied;
                CellInfoDictionary[cellInfo.Position].OccupyingObject = cellInfo.OccupyingObject;
            }
            else
            {
                CellInfoDictionary.Add(cellInfo.Position, cellInfo);
            }
        }

        public void RemoveCellInfo(Vector2Int position)
        {
            if (CellInfoDictionary.ContainsKey(position))
            {
                CellInfoDictionary.Remove(position);
            }
        }

        public bool TryGetCellInfo(Vector2Int position, out CellInfo cellInfo)
        {
            if (CellInfoDictionary.ContainsKey(position))
            {
                cellInfo = CellInfoDictionary[position];
                return true;
            }

            cellInfo = null;
            return false;
        }
    }
}
