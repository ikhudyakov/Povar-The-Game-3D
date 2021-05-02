using UnityEngine;

namespace povar3d
{
    internal class GameObjectBuilder
    {
        protected GameObject _gameObject;

        public GameObjectBuilder() => _gameObject = new GameObject();
        protected GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;
        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);
        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }
    }
}

