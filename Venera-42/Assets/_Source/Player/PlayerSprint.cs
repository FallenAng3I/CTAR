using UnityEngine;

namespace _Source.Player
{
    public class PlayerSprint : APlayerMovement
    {
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
                    moveSpeed = 3f;
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                Vector3 move = new Vector3(horizontal, 0, vertical) * (moveSpeed * Time.deltaTime);
                transform.Translate(move);
            }
        }
    }
}