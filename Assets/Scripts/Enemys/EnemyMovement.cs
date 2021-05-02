using UnityEngine;
using UnityEngine.AI;

namespace povar3d
{
    public class EnemyMovement : IExecute
    {
        private Transform _transform;
        private Transform _playerTransform;
        private Animator _animator;
        private Rigidbody _rigidbody;
        private NavMeshAgent _navMeshAgent;
        private float _moveSpeed;
        private float _rotationSpeed;
        private float _stopDistance;

        public EnemyMovement(Transform playerTransform, Transform enemyTransform, Animator animator, Rigidbody rigidbody, NavMeshAgent navMeshAgent, float moveSpeed, float rotationSpeed, float stopDistance)
        {
            _playerTransform = playerTransform;
            _transform = enemyTransform;
            _animator = animator;
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
            _stopDistance = stopDistance;
            _rotationSpeed = rotationSpeed;
            _navMeshAgent = navMeshAgent;
            //Временно
            _navMeshAgent.stoppingDistance = 1f;
        }

        public void Execute(float deltaTime)
        {
            if (CheckDistance() >= _stopDistance)
            {
                _navMeshAgent.SetDestination(_playerTransform.position);
                _animator.SetFloat("Speed", _moveSpeed);
            }
            else
            {
                _animator.SetFloat("Speed", 0.0f);
            }
        }

        internal virtual void Move(float deltaTime)
        {
            _transform.position += _transform.forward * _moveSpeed * deltaTime;
        }

        internal virtual void Rotation(float deltaTime)
        {
            _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.LookRotation(_playerTransform.position - _transform.position), _rotationSpeed * deltaTime);
        }

        internal float CheckDistance()
        {
            float distance = Vector3.Distance(_transform.position, _playerTransform.position);
            return distance;
        }
    }
}