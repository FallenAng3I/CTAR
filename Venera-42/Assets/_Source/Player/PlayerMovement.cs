using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public PlayerInventory weaponinv;
    private void Update()
    {
        MovePlayer();
    }

    public virtual void MovePlayer()
    {
          if (weaponinv.currentWeapon != null)
          {
              if (weaponinv.currentWeapon.scope)
              {
                  moveSpeed = 1f;
              }
              else
              {
                  moveSpeed = 1.5f;
              }
          }
        
          float horizontal = Input.GetAxis("Horizontal");
          float vertical = Input.GetAxis("Vertical");

          Vector3 move = new Vector3(horizontal, 0, vertical) * (moveSpeed * Time.deltaTime);

          transform.Translate(move);
    }
    
    
}
