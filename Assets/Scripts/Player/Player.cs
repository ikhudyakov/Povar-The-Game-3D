using UnityEngine;

namespace povar3d
{
    public sealed class Player : MonoBehaviour, IExecute, IFixedExecute, IPlayer
    {
        private float _moveSpeed;
        private int _allHealth;
        private int _health;

        private Animator _animator;
        private Rigidbody _rigidbody;
        private DynamicJoystick _dynamicJoystick;
        private Vector3 _moveDirection;

        private Weapon _weapon;

        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
        public int AllHealth { get => _allHealth; set => _allHealth = value; }
        public int Health { get => _health; set => _health = value; }
        public Animator PlayerAnimator { get => _animator; set => _animator = value; }
        public Rigidbody PlayerRigidbody { get => _rigidbody; set => _rigidbody = value; }
        public Vector3 MoveDirection { get => _moveDirection; set => _moveDirection = value; }

        private void Awake()
        {
            //Здоровье - переписать
            AllHealth = Health = 350;
            MoveSpeed = 2.2f;
            PlayerAnimator = GetComponent<Animator>();
            PlayerRigidbody = GetComponent<Rigidbody>();
            _dynamicJoystick = FindObjectOfType<DynamicJoystick>();
            _weapon = GetComponentInChildren<Weapon>();
        }

        public void Execute(float deltaTime)
        {
            MoveDirection = new Vector3(_dynamicJoystick.Horizontal, 0, _dynamicJoystick.Vertical).normalized;
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            Move();
        }

        //private void Update()
        //{
        //    MoveDirection = new Vector3(_dynamicJoystick.Horizontal, 0, _dynamicJoystick.Vertical).normalized;
        //}

        //void FixedUpdate()
        //{

        //    Vector3 down = Vector3.Project(PlayerRigidbody.velocity, transform.up);
        //    Vector3 forward = transform.forward * MoveSpeed;
        //    forward = Vector3.ClampMagnitude(forward, MoveSpeed);

        //    PlayerAnimator.SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);

        //    if (_dynamicJoystick.Horizontal != 0f || _dynamicJoystick.Vertical != 0f)
        //    {
        //        PlayerRigidbody.velocity = down + forward;
        //        transform.LookAt(MoveDirection + transform.position);
        //    }
        //}

        //Передвижение игрока(используется джойстик)
        private void Move()
        {
            MoveDirection = new Vector3(_dynamicJoystick.Horizontal, 0, _dynamicJoystick.Vertical).normalized;
            Vector3 down = Vector3.Project(PlayerRigidbody.velocity, transform.up);
            Vector3 forward = transform.forward * MoveSpeed;
            forward = Vector3.ClampMagnitude(forward, MoveSpeed);

            PlayerAnimator.SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);

            if (_dynamicJoystick.Horizontal != 0f || _dynamicJoystick.Vertical != 0f)
            {
                PlayerRigidbody.velocity = down + forward;
                transform.LookAt(MoveDirection + transform.position);
            }
        }

        //Атака игрока (переписать в отдельный класс)
        public void Attack()
        {
            if (_weapon is HandWeapon)
            {
                PlayerAnimator.SetFloat("HandAttack", 1.0f);
                _weapon.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        //Остановка Атаки игрока (переписать в отдельный класс)
        public void StopAttack()
        {
            if (_weapon is HandWeapon)
            {
                PlayerAnimator.SetFloat("HandAttack", 0.0f);
                _weapon.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }
}