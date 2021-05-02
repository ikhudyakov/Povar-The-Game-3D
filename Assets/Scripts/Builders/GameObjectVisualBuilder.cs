using UnityEngine;

namespace povar3d
{
    internal sealed class GameObjectVisualBuilder : GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectVisualBuilder AddEffects(GameObject effects)
        {
            var particalSystem = effects.GetComponent<ParticleSystem>();
            effects.transform.parent = _gameObject.transform;
            effects.transform.position = _gameObject.transform.position;
            particalSystem.Stop();
            var main = particalSystem.main;
            main.duration = 0.2f;
            main.loop = false;
            particalSystem.Play();
            return this;
        }
    }
}