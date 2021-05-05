using UnityEngine;

namespace povar3d
{
    public class PlayerAttack : IAttack
    {
        private Weapon _weapon;
        private Animator _animator;
        private Collider _collider;
        private GameObjectBuilder effects;

        public PlayerAttack(Weapon weapon, Animator animator)
        {
            _weapon = weapon;
            _animator = animator;
            _collider = _weapon.GetComponent<CapsuleCollider>();
        }

        public void StartAttack()
        {
            if (_weapon is HandWeapon)
            {
                _animator.SetFloat("HandAttack", 1.0f);
                _collider.enabled = true;
                effects = new GameObjectBuilder();
                GameObject attackEffect = effects.Visual.Name("AttackEffect").AddEffects(Object.Instantiate(Resources.Load<GameObject>("Prefabs/Weapons/AttackEffect"))).Physics.SetPossition(_weapon.transform.position);
                GameObject.Destroy(attackEffect, 2f);
            }
        }

        public void StopAttack()
        {
            if (_weapon is HandWeapon)
            {
                _animator.SetFloat("HandAttack", 0.0f);
                _collider.enabled = false;
            }
        }
    }
}