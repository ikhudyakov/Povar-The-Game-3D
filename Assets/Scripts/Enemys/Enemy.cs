using UnityEngine;
using UnityEngine.AI;

namespace povar3d
{
    public class Enemy : MonoBehaviour, IExecute, IEnemy
    {
        private int _health;
        private float _moveSpeed;
        private float _rotationSpeed;
        private float _stopDistance;
        private TextMesh _healthText;
        private Transform _playerTransform;
        private Animator _animator;
        private Rigidbody _rigidbody;
        private NavMeshAgent _navMeshAgent;
        private Collider _collider;
        private Weapon _weapon;
        private EnemyAttack _attack;
        private EnemyMovement _movement;

        public int Health { get => _health; set => _health = value; }
        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
        public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
        public float StopDistance { get => _stopDistance; set => _stopDistance = value; }
        public TextMesh HealthText { get => _healthText; set => _healthText = value; }
        public Transform PlayerTransform { get => _playerTransform; set => _playerTransform = value; }
        public Animator EnemyAnimator { get => _animator; set => _animator = value; }
        public Rigidbody EnemyRigidbody { get => _rigidbody; set => _rigidbody = value; }
        public NavMeshAgent NavMeshAgent { get => _navMeshAgent; set => _navMeshAgent = value; }
        public EnemyAttack Attack { get => _attack; set => _attack = value; }
        public Collider EnemyCollider { get => _collider; set => _collider = value; }

        private void Start()
        {
            PlayerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
            EnemyAnimator = GetComponent<Animator>();
            EnemyRigidbody = GetComponent<Rigidbody>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            HealthText = GetComponentInChildren<TextMesh>();
            EnemyCollider = GetComponent<Collider>();
            HealthText.text = Health.ToString();
            _weapon = GetComponentInChildren<Weapon>();
            _attack = new EnemyAttack(_weapon, _animator);
            _movement = new EnemyMovement(_playerTransform, transform, EnemyAnimator, EnemyRigidbody, NavMeshAgent, MoveSpeed, RotationSpeed, StopDistance);
        }

        public void Execute(float deltaTime)
        {
            _movement.Execute(deltaTime);
            _attack.StartAttack();
            CheckHealth();
        }

        //Переписать в отдельный класс
        internal void GetDamage(int damage)
        {
            Health -= damage;
            HealthText.text = Health.ToString();
            EnemyAnimator.SetTrigger("TakeDamage");
        }

        //Временно, подумать, как сделать лучше 
        internal void CheckHealth()
        {
            if (Health <= 0)
            {
                Health = 0;
                HealthText.text = Health.ToString();
                Destroy(gameObject, 3f);
                EnemyAnimator.SetLayerWeight(2, 1f);
                EnemyAnimator.SetBool("Death", true);
                NavMeshAgent.stoppingDistance = 100f;
                EnemyRigidbody.isKinematic = true;
                EnemyCollider.enabled = false;
            }
        }
    }
}