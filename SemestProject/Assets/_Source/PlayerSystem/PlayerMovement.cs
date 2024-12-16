using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        public Player player;
        private Vector2 _move;
        private Animator _animator;
        private static readonly int IsMovingLeft = Animator.StringToHash("isMovingLeft");
        private static readonly int IsMovingForward = Animator.StringToHash("isMovingForward");
        private static readonly int IsMovingBackward = Animator.StringToHash("isMovingBackward");
        private static readonly int IsMovingRight = Animator.StringToHash("isMovingRight");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void Update()
        {
            MovePlayer();
            UpdateAnimation();
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
        
        private void UpdateAnimation()
        {
            _animator.SetBool(IsMovingForward, false);
            _animator.SetBool(IsMovingBackward, false);
            _animator.SetBool(IsMovingLeft, false);
            _animator.SetBool(IsMovingRight, false);

            if (_move.y > 0.1f)
            {
                _animator.SetBool(IsMovingForward, true);
            }
            else if (_move.y < -0.1f)
            {
                _animator.SetBool(IsMovingBackward, true);
            }

            if (_move.x < -0.1f)
            {
                _animator.SetBool(IsMovingLeft, true);
            }
            else if (_move.x > 0.1f)
            {
                _animator.SetBool(IsMovingRight, true);
            }
            
            if (_move.magnitude < 0.1f)
            {
                _animator.SetBool(IsMovingForward, false);
                _animator.SetBool(IsMovingBackward, false);
                _animator.SetBool(IsMovingLeft, false);
                _animator.SetBool(IsMovingRight, false);
            }
        }
    }
}