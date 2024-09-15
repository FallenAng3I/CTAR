using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followAxis = 0; // Ось, по которой будет следовать камера (1 - X, 2 - Y, 3 - Z)
    public float offset = 0f;

    private void LateUpdate()
    {
            Vector3 newPosition = transform.position;
            
            switch (followAxis)
            {
                case 1:
                    newPosition.x = player.position.x + offset;
                    break;
                case 2:
                    newPosition.y = player.position.y + offset;
                    break;
                case 3:
                    newPosition.z = player.position.z + offset;
                    break;
                default:
                    Debug.LogWarning("Выберите корректную ось для следования (1, 2 или 3).");
                    return;
            }
            transform.position = newPosition;
    }
}