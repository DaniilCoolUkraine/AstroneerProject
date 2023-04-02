using System;
using UnityEngine;

namespace Astroneer.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public event Action<bool> OnPlayerMove;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _speed;
        [Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;
        
        private bool _facingRight = false;
        private Vector3 _velocity = Vector3.zero;

        private float _horizontalInput;
        
        // todo rewrite. really
        private bool _isMoving = false;
        private bool IsMoving
        {
            get => _isMoving;
            set
            {
                if (_isMoving != value)
                {
                    _isMoving = value;
                    OnPlayerMove?.Invoke(_isMoving);
                }
            }
        }
        
        private float _multiplier = 10;

        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");

            if (_horizontalInput != 0)
            {
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            Vector3 targetVelocity = new Vector2(_horizontalInput * _speed * Time.fixedDeltaTime * _multiplier, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity =
                Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);
            
            // flip character
            if (_horizontalInput > 0 && !_facingRight)
            {
            	Flip();
            }
            else if (_horizontalInput < 0 && _facingRight)
            {
            	Flip();
            }
        }
        
        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            _facingRight = !_facingRight;
            
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}