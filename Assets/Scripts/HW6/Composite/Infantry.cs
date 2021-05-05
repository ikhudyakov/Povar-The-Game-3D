using UnityEngine;

namespace hw6
{
    public class Infantry : IUnit
    {
        private float _health;

        public Infantry(float health)
        {
            Health = health;
            Debug.Log($"���: {typeof(Infantry)}\n��������: {health}");
        }

        public float Health { get => _health; set => _health = value; }
    }
}