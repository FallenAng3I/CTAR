using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        public Player player;
        private Vector2 _move;

        private void Update()
        {
            MovePlayer();
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            _move = context.ReadValue<Vector2>();
        }

        private void MovePlayer()
        {
            Vector3 movement = new Vector3(_move.x, 0f, _move.y);
            transform.Translate(movement * (player.speed * Time.deltaTime), Space.World);
        }
    }
}