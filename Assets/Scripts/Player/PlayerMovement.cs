using UnityEngine;

namespace povar3d
{
    public class PlayerMovement : IExecute
    {
        private float _moveSpeed;

        private Transform _transform;
        private Animator _animator;
        private Rigidbody _rigidbody;

        private InputController _input;
        private Vector3 _moveDirection;

        public PlayerMovement(Transform playerTransform, Rigidbody playerRigidbody, Animator playerAnimator, float moveSpeed, InputController input)
        {
            _transform = playerTransform;
            _rigidbody = playerRigidbody;
            _animator = playerAnimator;
            _moveSpeed = moveSpeed;
            _input = input;
        }

        public void Move()
        {
            _moveDirection = new Vector3(_input.Horizontal, 0, _input.Vertical).normalized;
            Vector3 down = Vector3.Project(_rigidbody.velocity, _transform.up);
            Vector3 forward = _transform.forward * _moveSpeed;
            forward = Vector3.ClampMagnitude(forward, _moveSpeed);

            _animator.SetFloat("Speed", _animator.GetComponent<Rigidbody>().velocity.magnitude);

            if (_input.Horizontal != 0f || _input.Vertical != 0f)
            {
                _rigidbody.velocity = down + forward;
                _transform.LookAt(_moveDirection + _transform.position);
            }
        }

        public void Execute(float deltaTime)
        {
            _moveDirection = new Vector3(_input.Horizontal, 0, _input.Vertical).normalized;
        }
    }
}