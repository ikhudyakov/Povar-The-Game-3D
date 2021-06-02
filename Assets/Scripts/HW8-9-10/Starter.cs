using UnityEngine;

namespace MVVM
{
    internal sealed class Starter : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private InputView _inputView;
        [SerializeField] private BonusView _bonusView;

        private void Start()
        {
            var playerModel = new PlayerModel();
            var playerViewModel = new PlayerViewModel(playerModel);
            _playerView.Initialize(playerViewModel, _inputView);
        }

        private void Update()
        {
            _playerView.Execute(Time.deltaTime);
            _inputView.Execute(Time.deltaTime);
        }
    }
}

