using UnityEngine;

namespace MVVM
{
    internal sealed class PlayerModel : IPlayerModel
    {
        public int Length { get; set; }

        public PlayerModel()
        {
            Length = 0;
        }
    }
}