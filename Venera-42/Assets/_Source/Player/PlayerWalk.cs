using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerMovement
{
    public float moveSpeed =5f;
    
    public override void MovePlayer()
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
