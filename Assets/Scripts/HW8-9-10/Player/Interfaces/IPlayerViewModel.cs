using System;

namespace MVVM
{
    internal interface IPlayerViewModel
    {
        IPlayerModel PlayerModel { get; }
        void Increase();
        event Action<int> OnLengthChange;

    }
}