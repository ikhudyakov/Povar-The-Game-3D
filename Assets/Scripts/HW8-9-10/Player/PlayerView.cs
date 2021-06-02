using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    internal sealed class PlayerView : MonoBehaviour, IExecute
    {
        [SerializeField] private Text _text;
        [SerializeField] private BonusView _bonusView;
        [SerializeField] private GameObject _bone;
        [SerializeField] private List<Transform> _tails;
        [SerializeField] private float _boneDistance;
        private IPlayerViewModel _playerViewModel;
        private InputView _inputView;

        public void Initialize(IPlayerViewModel playerViewModel, InputView inputView)
        {
            _playerViewModel = playerViewModel;
            _inputView = inputView;
            playerViewModel.OnLengthChange += OnLengthChange;
            OnLengthChange(_playerViewModel.PlayerModel.Length);
        }

        public void Execute(float deltaTime)
        {
            transform.position = transform.position + transform.forward * 4f * deltaTime;
            Rotate();
            MoveTail();
        }

        private void MoveTail()
        {
            float distance = Mathf.Sqrt(_boneDistance);
            Vector3 prevPosition = transform.position;

            foreach (var bone in _tails)
            {
                if((bone.position - prevPosition).sqrMagnitude > distance)
                {
                    Vector3 currentBonePosition = bone.position;
                    bone.position = prevPosition;
                    prevPosition = currentBonePosition;
                }
                else
                {
                    break;
                }
            }
        }

        private void Rotate()
        {
            transform.Rotate(0, _inputView.Angle, 0);
        }

        private void OnTriggerEnter(Collider bonusCollider)
        {
            if (bonusCollider.TryGetComponent<BonusView>(out BonusView bonusView))
            {
                Destroy(bonusView.gameObject);
                _playerViewModel.Increase();
                GameObject bone = Instantiate(_bone);
                _tails.Add(bone.transform);
            }
        }

        private void OnLengthChange(int length)
        {
            _text.text = Utils.Interpreter.numbersToLetters(length);
            var bonusModel = new BonusModel();
            var bonusViewModel = new BonusViewModel(bonusModel);
            var bonus = Object.Instantiate(_bonusView);
            bonus.Initialize(bonusViewModel);
        }

        ~PlayerView()
        {
            _playerViewModel.OnLengthChange -= OnLengthChange;
        }
    }
}