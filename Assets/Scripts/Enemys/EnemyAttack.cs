using UnityEngine;

namespace povar3d
{

    public class EnemyAttack : IAttack
    {
        private Weapon _weapon;
        private Animator _animator;
        private Collider _collider;

        public EnemyAttack(Weapon weapon, Animator animator)
        {
            _weapon = weapon;
            _animator = animator;
            _collider = _weapon.GetComponentInChildren<SphereCollider>();
        }

        public void StartAttack()
        {
            if (_weapon is IHandWeapon)
            {
                _animator.SetFloat("HandAttack", 1.0f);
                _collider.enabled = true;
            }
        }

        public void StopAttack()
        {
            if (_weapon is IHandWeapon)
            {
                _animator.SetFloat("HandAttack", 0.0f);
                _collider.enabled = false;
            }
        }
    }
}