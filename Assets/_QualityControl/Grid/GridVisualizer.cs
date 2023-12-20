    using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace TowerDefenseGame.GridLayout
{
    [RequireComponent(typeof(Grid))]
    public class GridVisualizer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Grid _grid;
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private GridConfig _gridConfig;

        [Space(10)]

        [Header("Tile Config")]
        [SerializeField] private Color _tileColor;
        private int _width => _gridConfig.Width;
        private int _height => _gridConfig.Height;
        private Vector3 _cellSize => _gridConfig.CellSize;
        private Vector3 _cellGap => _gridConfig.CellGap;
        
        private void Start()
        {
            FillGrid();
        }

        private void FillGrid()
        {
            Vector2Int cellSize = new Vector2Int((int)_cellSize.x, (int)_cellSize.y);
            Vector2Int cellGap = new Vector2Int((int)_cellGap.x, (int)_cellGap.y);

            Vector2Int initialCell = new Vector2Int((int)(-_width / 2), (int)(-_height / 2));

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Vector2Int cellPosition = initialCell + new Vector2Int(x, y);

                    Vector3 center = _grid.GetCellCenterWorld(new Vector3Int(cellPosition.x, cellPosition.y, 0));
                    GameObject tile = Instantiate(_tilePrefab, center, Quaternion.identity);
                    tile.GetComponent<SpriteRenderer>().color = _tileColor;
                    tile.transform.parent = transform;

                    

                    //original scale is set to be the same as a unity cube so we can use a rule of three to calculate the scale
                    Vector2 newScale = new Vector2(tile.transform.localScale.x, tile.transform.localScale.y);
                    newScale.x *= cellSize.x - cellGap.x;
                    newScale.y *= cellSize.y - cellGap.y;

                    tile.transform.localScale = new Vector3(newScale.y, newScale.x, 0);
                    tile.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 90);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(_width * (_cellSize.x + _cellGap.x), 1f, _height * (_cellSize.y + _cellGap.y)));

        }
    }
}
