using System;
using UnityEngine;

namespace MVVM
{
    internal sealed class PlayerViewModel : IPlayerViewModel
    {
        public event Action<int> OnLengthChange;
        public IPlayerModel PlayerModel { get; }


        public PlayerViewModel(IPlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }

        public void Increase()
        {
            PlayerModel.Length += 1000;
            OnLengthChange?.Invoke(PlayerModel.Length);
        }
    }
}