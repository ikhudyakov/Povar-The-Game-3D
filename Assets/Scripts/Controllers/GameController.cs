using UnityEngine;

namespace povar3d
{
    public class GameController : MonoBehaviour
    {
        private Controllers _controllers;
        private CameraController _cameraController;
        private InputController _inputController;
        private ListExecuteObject _interactiveObject;
        private ListFixedExecuteObject _fixedExecuteObject;
        private Player player;
        private Enemy enemy;
        private FrieData enemyData;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            _fixedExecuteObject = new ListFixedExecuteObject();

            IPlayerFactory playerFactory = new PlayerFactory();
            player = playerFactory.Create();

            _interactiveObject.AddExecuteObject(player);
            _fixedExecuteObject.AddExecuteObject(player);

            _inputController = new MobileInputController(player);
            _interactiveObject.AddExecuteObject(_inputController);

            _cameraController = new CameraController(player.transform, Camera.main.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            enemyData = new FrieData(1000, 1.5f, 3.0f, 1.0f);
            IEnemyFactory enemyFactory = new FrieFactory();
            enemy = enemyFactory.Create(enemyData);

            //Копирование объекта
            Enemy enemyCopy = enemyFactory.Create(enemyData.DeepCopy());

            _interactiveObject.AddExecuteObjects(FindObjectsOfType<Enemy>());
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

                if (interactiveObject.Equals(null))
                {
                    _interactiveObject.DeleteExecuteObject(interactiveObject);
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
                    _fixedExecuteObject.DeleteExecuteObject(interactiveObject);
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