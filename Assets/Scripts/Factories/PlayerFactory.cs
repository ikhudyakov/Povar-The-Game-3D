using UnityEngine;

namespace povar3d
{
    internal sealed class PlayerFactory : IPlayerFactory
    {
        public Player Create()
        {
            var player = Object.Instantiate(Resources.Load<Player>("Prefabs/Player"));
            player.AllHealth = 350;
            player.MoveSpeed = 2.2f;
            return player;
        }
    }
}