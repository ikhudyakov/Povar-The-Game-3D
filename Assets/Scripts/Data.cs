using UnityEngine;

namespace povar3d
{
    public class Data
    {
        private Player _player;
        private Camera _mainCamera;
        private Canvas _canvas;

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public Player Player
        {
            get
            {
                if (_player == null)
                {
                    var gameObject = Resources.Load<Player>("Prefabs/Player");
                    _player = Object.Instantiate(gameObject);
                    _player.GetComponent<PlayerGravityBody>().enabled = true;
                }

                return _player;
            }
        }

        public Camera MainCamera
        {
            get
            {
                return Camera.main;
            }
        }
    }
}