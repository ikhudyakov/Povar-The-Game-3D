using UnityEngine;

namespace povar3d
{
    public class Enemy : MonoBehaviour, IExecute, IEnemy
    {
        private int _health;
        private TextMesh _healthText;

        private Animator _animator;
        private Rigidbody _rigidbody;
        private Transform _playerTransform;
        private float _rotationSpeed;
        private float _moveSpeed;
        private float _stopDistance;

        public int Health { get => _health; set => _health = value; }
        public TextMesh HealthText { get => _healthText; set => _healthText = value; }
        public Animator EnemyAnimator { get => _animator; set => _animator = value; }
        public Rigidbody EnemyRigidbody { get => _rigidbody; set => _rigidbody = value; }
        public Transform PlayerTransform { get => _playerTransform; set => _playerTransform = value; }
        public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
        public float StopDistance { get => _stopDistance; set => _stopDistance = value; }

        //Переписать
        private void Start()
        {
            PlayerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
            EnemyAnimator = GetComponent<Animator>();
            EnemyRigidbody = GetComponent<Rigidbody>();
        }

        public void Execute(float deltaTime)
        {
            if (this.gameObject != null)
            {
                if (CheckDistance() >= StopDistance)
                {
                    Move();
                    Rotation();
                    EnemyAnimator.SetFloat("Speed", _moveSpeed);
                }
                else
                {
                    EnemyAnimator.SetFloat("Speed", 0.0f);
                }
                Attack();
                CheckHealth();
            }
        }

        internal void GetDamage(int damage)
        {
            Health -= damage;
            HealthText.text = Health.ToString();
        }

        //Метод атаки врага (переписать в отдельный класс)
        internal virtual void Attack()
        {

        }

        //Метод передвижения врага
        internal virtual void Move()
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        
        internal virtual void Rotation()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerTransform.position - transform.position), RotationSpeed * Time.deltaTime);
        }

        internal float CheckDistance()
        {
            float d = Vector3.Distance(gameObject.transform.position, _playerTransform.position);
            return d;
        }

        //Проверка жизни врага, если меньше 0, уничтожаем
        internal void CheckHealth()
        {
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}