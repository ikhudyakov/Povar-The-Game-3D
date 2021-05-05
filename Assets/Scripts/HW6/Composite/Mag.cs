using UnityEngine;

namespace hw6
{
    public class Mag : IUnit
    {
        private float _health;

        public Mag(float health)
        {
            Health = health;
            Debug.Log($"���: {typeof(Mag)}\n��������: {health}");
        }

        public float Health { get => _health; set => _health = value; }
    }
}