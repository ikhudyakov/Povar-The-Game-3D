using UnityEngine;

namespace povar3d
{

    public class Knuckle : Weapon, IHandWeapon
    {
        public int Damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.GetDamage(Damage);
            }
        }
    }
}