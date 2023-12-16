using System;
using UnityEngine;

namespace TowerDefenseGame.Pathfinding
{
    public class PathfindingDirectionSwapper : MonoBehaviour
    {
        [SerializeField]private Vector3 _newDirection;

        internal void GetNewDirection(out Vector3 newDirection)
        {
            newDirection = _newDirection;
        }

        private void OnDrawGizmos() {
            // draw an arrow in the new direction
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + _newDirection * 2f);
        }

    }
}
