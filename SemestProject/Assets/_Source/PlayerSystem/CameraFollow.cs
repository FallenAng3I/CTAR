using UnityEngine;

namespace PlayerSystem
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform player;
        public Vector3 offset;

        void LateUpdate()
        {
            transform.position = player.position + offset;
        }
    }
}