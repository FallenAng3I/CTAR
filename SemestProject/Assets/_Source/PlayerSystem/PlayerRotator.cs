using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerSystem
{
    public class PlayerRotator : MonoBehaviour
    {
        private Camera _mainCamera;
        [SerializeField] private float offsetRotationY;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            RotateTowardsCursor();
        }

        private void RotateTowardsCursor()
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 targetPosition = hitInfo.point;
                targetPosition.y = transform.position.y;
                Vector3 direction = targetPosition - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                var offsetRotation = rotation.eulerAngles;
                offsetRotation = new Vector3(offsetRotation.x, offsetRotation.y + offsetRotationY, offsetRotation.z);
                transform.rotation = Quaternion.Euler(offsetRotation);
            }
        }
    }
}