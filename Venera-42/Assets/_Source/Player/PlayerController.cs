using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask groundLayer;
    public Transform player;
    

    void Update()
    {
        RotatePlayerTowardsCursor();
    }

    void RotatePlayerTowardsCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundLayer))
        {
            Vector3 targetPosition = hitInfo.point;
            targetPosition.y = player.position.y;
            
            Vector3 direction = (targetPosition - player.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            player.rotation = lookRotation;
        }
    }
}

