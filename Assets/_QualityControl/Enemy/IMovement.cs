using UnityEngine;

namespace TowerDefenseGame
{
    public interface IMovement 
    {
        void Move(Vector3 direction, float speed);
        void MoveTowards(Vector3 target, float speed);
        void Rotate(Vector3 direction, float speed = 1f);
    }
}
