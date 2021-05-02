using UnityEngine;

namespace povar3d
{
    internal sealed class FrieFactory : IEnemyFactory
    {
        public Enemy Create()
        {
            var enemy = Object.Instantiate(Resources.Load<Frie>("Prefabs/frie"));
            return enemy;
        }
    }
}