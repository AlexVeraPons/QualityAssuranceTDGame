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
    }
}
