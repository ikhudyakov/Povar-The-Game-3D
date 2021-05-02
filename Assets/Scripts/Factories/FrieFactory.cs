using UnityEngine;

namespace povar3d
{
    internal sealed class FrieFactory : IEnemyFactory
    {
        public Enemy Create()
        {
            var enemy = Object.Instantiate(Resources.Load<Frie>("Prefabs/frie"));
            enemy.Health = 1000;
            enemy.RotationSpeed = 3.0f;
            enemy.MoveSpeed = 1.5f;
            enemy.StopDistance = 1.0f;
            return enemy;
        }
    }
}