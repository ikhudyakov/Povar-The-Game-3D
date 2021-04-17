using UnityEngine;

namespace povar3d
{
    public class Data
    {
        private Player _player;
        private Enemy _frie;
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
                }

                return _player;
            }
        }
        
        public Enemy Frie
        {
            get
            {
                if (_frie == null)
                {
                    var gameObject = Resources.Load<Frie>("Prefabs/frie");
                    _frie = Object.Instantiate(gameObject);
                }

                return _frie;
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