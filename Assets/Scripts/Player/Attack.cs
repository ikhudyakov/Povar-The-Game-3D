using UnityEngine;

namespace povar3d
{
    public class Attack 
    {
        private Weapon _weapon;
        private Animator _animator;

        public Attack(Weapon weapon, Animator animator)
        {
            _weapon = weapon;
            _animator = animator;
        }

        public void StartAttack()
        {
            if (_weapon is HandWeapon)
            {
                _animator.SetFloat("HandAttack", 1.0f);
                _weapon.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        public void StopAttack()
        {
            if (_weapon is HandWeapon)
            {
                _animator.SetFloat("HandAttack", 0.0f);
                _weapon.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }
}