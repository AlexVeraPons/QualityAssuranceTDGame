using UnityEngine;

namespace TowerDefenseGame.Enemy
{
    public class DebugEnemyInformation : MonoBehaviour
    {

        private void OnDrawGizmos() {
            // draw a line forward
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2f);
        }
    }
}
