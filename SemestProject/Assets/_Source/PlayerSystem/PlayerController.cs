using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerSystem
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector2 _move;

        public void OnMove(InputAction.CallbackContext context)
        {
            _move = context.ReadValue<Vector2>();
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            Vector3 movement = new Vector3(_move.x, 0f, _move.y);
            transform.Translate(movement * (speed * Time.deltaTime), Space.World);
        }
    }
}