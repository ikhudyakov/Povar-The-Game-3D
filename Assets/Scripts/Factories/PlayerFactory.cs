using UnityEngine;

namespace povar3d
{
    internal sealed class PlayerFactory : IPlayerFactory
    {
        public Player Create()
        {
            var player = Object.Instantiate(Resources.Load<Player>("Prefabs/Player"));
            return player;
        }
    }
}