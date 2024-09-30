using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    
    public PlayerInventory weaponinv;
    private void Update()
    {
        MovePlayer();
    }

    public abstract void MovePlayer();
    
    
}
