using UnityEngine;

namespace povar3d
{
    internal sealed class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectPhysicsBuilder SetPossition(Vector3 position)
        {
            _gameObject.transform.position = position;
            return this;
        }
    }
}