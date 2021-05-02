using UnityEngine;

namespace povar3d
{
    public class HandWeapon : Weapon, IHandWeapon
    {
        public int Damage;

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.GetDamage(Damage);
            }
        }
    }
}