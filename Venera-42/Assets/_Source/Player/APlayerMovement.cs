using _Source.NewWeaponScript;
using UnityEngine;
namespace _Source.Player
{
    public abstract class APlayerMovement : MonoBehaviour
    {
        public float moveSpeed;
        public PlayerAndWeapons weaponinv;

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
}