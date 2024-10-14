using UnityEngine;

namespace _Source
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothSpeed = 0.125f;

        void LateUpdate()
        {
            if (player == null) return;
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(player);
        }
    }
}