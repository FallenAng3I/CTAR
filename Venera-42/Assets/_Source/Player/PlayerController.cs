using UnityEngine;

namespace _Source.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Camera mainCamera;
        public Transform player;

        void Update()
        {
            RotatePlayerTowardsCursor();
        }

        void RotatePlayerTowardsCursor()
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 targetPosition = hitInfo.point;
                targetPosition.y = player.position.y;
                Vector3 direction = (targetPosition - player.position).normalized;
                if (direction.magnitude > 0.1f)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    player.rotation = lookRotation;
                }
            }
        }
    }
}