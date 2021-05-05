using System;

namespace povar3d
{
    [Serializable]
    public class FrieData
    {
        private int _health;
        private float _moveSpeed;
        private float _rotationSpeed;
        private float _stopDistance;

        public FrieData(int health, float moveSpeed, float rotationSpeed, float stopDistance)
        {
            _health = health;
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
            _stopDistance = stopDistance;
        }

        public int Health { get => _health;}
        public float MoveSpeed { get => _moveSpeed;}
        public float RotationSpeed { get => _rotationSpeed;}
        public float StopDistance { get => _stopDistance;}
    }
}