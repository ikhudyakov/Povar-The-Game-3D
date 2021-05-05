namespace hw6
{
    public sealed class UnlockAttack
    {
        public bool IsUnlock { get; set; }

        public UnlockAttack(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }
    }
}