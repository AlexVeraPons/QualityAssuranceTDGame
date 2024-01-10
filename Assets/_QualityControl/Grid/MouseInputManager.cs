using System;
using UnityEngine;

namespace TowerDefenseGame.GridLayout
{
    public class MouseInputManager : MonoBehaviour
    {
        public Action OnLeftMouseButtonDown;

        public Action OnRightMouseButtonDown;

        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _layerMask;

        private Vector3 _lastMousePosition;

        public Vector3 GetMousePosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _camera.nearClipPlane;

            Ray ray = _camera.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray, out hitInfo, 100, _layerMask))
            {
                _lastMousePosition = hitInfo.point;
            }

            return _lastMousePosition;
        }

        public bool IsMouseOverLayer()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _camera.nearClipPlane;

            Ray ray = _camera.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray, out hitInfo, 100, _layerMask))
            {
                return true;
            }

            return false;
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0))
            {
                OnLeftMouseButtonDown?.Invoke();
            }

            if (Input.GetMouseButtonDown(1))
            {
                OnRightMouseButtonDown?.Invoke();
            }
        }

    }
}
