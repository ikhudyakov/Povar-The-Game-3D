using povar3d;

namespace hw6
{
    public class AttackProxy : IAttack
    {
        private readonly IAttack _attack;
        private readonly UnlockAttack _unlockAttack;

        public AttackProxy(IAttack attack, UnlockAttack unlockAttack)
        {
            _attack = attack;
            _unlockAttack = unlockAttack;
        }

        public void StartAttack()
        {
            if (_unlockAttack.IsUnlock)
            {
                _attack.StartAttack();
            }
        }

        public void StopAttack()
        {
            if (_unlockAttack.IsUnlock)
            {
                _attack.StopAttack();
            }
        }
    }
}