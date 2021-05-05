using UnityEngine;

namespace povar3d
{
    internal sealed class FrieFactory : IEnemyFactory
    {
        public Enemy Create(FrieData data)
        {
            var enemy = Object.Instantiate(Resources.Load<Frie>("Prefabs/frie"));
            enemy.Health = data.Health;
            enemy.RotationSpeed = data.RotationSpeed;
            enemy.MoveSpeed = data.MoveSpeed;
            enemy.StopDistance = data.StopDistance;
            return enemy;
        }
    }
}