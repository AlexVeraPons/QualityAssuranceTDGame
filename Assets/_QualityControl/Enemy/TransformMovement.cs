using UnityEngine;

namespace TowerDefenseGame
{
    public class TransformMovement : MonoBehaviour, IMovement
    {
        public void Move(Vector3 direction, float speed)
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        public void MoveTowards(Vector3 target, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        public void Rotate(Vector3 direction, float speed = 1f)
        {
            transform.forward = direction;
        }
    }
}
