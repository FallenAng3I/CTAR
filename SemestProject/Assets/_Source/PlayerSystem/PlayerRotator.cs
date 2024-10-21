using UnityEngine;
using UnityEngine.InputSystem;

namespace _Source.PlayerSystem
{
    public class PlayerRotator : MonoBehaviour
    {
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            RotateTowardsCursor();
        }

        private void RotateTowardsCursor()
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 targetPosition = hitInfo.point;
                targetPosition.y = transform.position.y;
                Vector3 direction = targetPosition - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
            }
        }
    }
}