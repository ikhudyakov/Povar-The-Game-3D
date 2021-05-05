using System;
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
        private PlayerMovement _movement;
        private Weapon _weapon;
        private PlayerAttack _attack;
        private InputController _input;
        private UIHealth _uIHealth;

        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
        public int AllHealth { get => _allHealth; set => _allHealth = value; }
        public int Health { get => _health; set => _health = value; }
        public Animator PlayerAnimator { get => _animator; set => _animator = value; }
        public Rigidbody PlayerRigidbody { get => _rigidbody; set => _rigidbody = value; }
        public PlayerAttack Attack { get => _attack; set => _attack = value; }
        public InputController Input { get => _input; set => _input = value; }

        private void Awake()
        {
            PlayerAnimator = GetComponent<Animator>();
            PlayerRigidbody = GetComponent<Rigidbody>();
            _weapon = GetComponentInChildren<Weapon>();
            _attack = new PlayerAttack(_weapon, _animator);
            _uIHealth = new UIHealth(this);
        }

        private void Start()
        {
            Health = AllHealth;
            _movement = new PlayerMovement(transform, PlayerRigidbody, PlayerAnimator, MoveSpeed, Input);
        }

        public void Execute(float deltaTime)
        {
            _movement.Execute(deltaTime);
            _uIHealth.Execute(deltaTime);
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            _movement.Move();
        }

        internal void GetDamage(int damage)
        {
            Health -= damage;
        }
    }
}