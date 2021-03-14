using System.Collections.Generic;
using UnityEngine;

namespace povar3d
{
    public class GameController : MonoBehaviour
    {
        private Controllers _controllers;
        private ListExecuteObject _interactiveObject;
        private ListFixedExecuteObject _fixedExecuteObject;
        private Player player;
        private Data data;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            _fixedExecuteObject = new ListFixedExecuteObject();
            data = new Data();
            player = data.Player;
            _interactiveObject.AddExecuteObject(player);
            _fixedExecuteObject.AddExecuteObject(player);

            //Переписать нормально!
            _interactiveObject.AddExecuteObject(FindObjectOfType<Enemy>());
        }

        private void Start()
        {
            _controllers = new Controllers();
            //new GameInitialization(_controllers, _data);
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);

            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute(deltaTime);
            }
        }
        
        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _controllers.FixedExecute(fixedDeltaTime);

            for (var i = 0; i < _fixedExecuteObject.Length; i++)
            {
                var interactiveObject = _fixedExecuteObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.FixedExecute(fixedDeltaTime);
            }
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}