using System.Collections.Generic;
using UnityEngine;

using Vector3 = UnityEngine.Vector3;

namespace TowerDefenseGame.Pathfinding
{
    internal class PathfindingPoint
    {
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }
    }

    public class ConveyorPathFinding : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private List<PathfindingPoint> _path = new List<PathfindingPoint>();

        private IMovement _movement;
        private void Awake()
        {
            _movement = GetComponent<IMovement>();
        }
        private void OnEnable()
        {
            const int maxLoopCount = 100;
            int loopCount = 0;

            while (GetNextPathPoint(out Vector3 nextPoint, out Vector3 nextDirection))
            {
                _path.Add(new PathfindingPoint() { Position = nextPoint, Direction = nextDirection });

                loopCount++;
                if (loopCount >= maxLoopCount)
                {
                    Debug.LogError("Maximum loop count reached. Exiting loop to avoid infinite loops.");
                    break;
                }
            }
        }
        private void Start() {
            if(_speed == 0f) {
                Debug.LogError("Speed is 0. Please set a speed value.");
            }
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        private bool GetNextPathPoint(out Vector3 nextPoint, out Vector3 nextDirection)
        {
            nextPoint = Vector3.zero;
            nextDirection = Vector3.zero;

            Vector3 pathPoint = _path.Count == 0 ? transform.position : _path[_path.Count - 1].Position;
            Vector3 pathDirection = _path.Count == 0 ? transform.forward : _path[_path.Count - 1].Direction;

            float MaxDistance = 100f;

            RaycastHit hit;
            if (Physics.Raycast(pathPoint, pathDirection, out hit, MaxDistance))
            {
                if (hit.collider.gameObject.GetComponent<PathfindingDirectionSwapper>() != null)
                {
                    nextPoint = hit.transform.position;
                    hit.collider.gameObject.GetComponent<PathfindingDirectionSwapper>().GetNewDirection(out Vector3 newDirection);
                    nextDirection = newDirection;

                    return true;
                }
                else if (hit.collider.gameObject.GetComponent<IPathfindingGoal>() != null)
                {
                    nextPoint = hit.point;
                    return true;
                }
            }
            return false;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.1f);
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5f);
            for (int i = 0; i < _path.Count; i++)
            {
                Gizmos.DrawWireSphere(_path[i].Position, 0.5f);
                Gizmos.DrawLine(_path[i].Position, _path[i].Position + _path[i].Direction * 5f);
            }
        }

        //TODO: this needs to get extracted into a separate class
        private void Update()
        {
            if (_path.Count == 0) { return; }

            _movement.MoveTowards(_path[0].Position, _speed);

            if (Vector3.Distance(transform.position, _path[0].Position) < 0.1f)
            {
                _path.RemoveAt(0);
            }
        }
    }
}
