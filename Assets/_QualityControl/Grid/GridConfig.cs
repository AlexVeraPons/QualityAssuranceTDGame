using System.Collections.Generic;
using UnityEngine;

namespace TowerDefenseGame.GridLayout
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "TowerDefenseGame/GridConfig", order = 0)]
    public class GridConfig : ScriptableObject 
    {
        public int Width;
        public int Height;

        public Vector3 CellSize;
        public Vector3 CellGap;
    }

    public class CellInfo
    {
        public Vector2Int Position;
        public bool IsOccupied;
        public GameObject OccupyingObject;
    }
}
