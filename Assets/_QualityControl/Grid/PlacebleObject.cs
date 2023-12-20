using Unity.VisualScripting;
using UnityEngine;

namespace TowerDefenseGame.GridLayout
{
    public class PlacebleObject :MonoBehaviour , IPlacebleObject
    {
        public void Place(Vector3 placedPosition)
        {
            this.transform.position = placedPosition;
        }
    }
}
