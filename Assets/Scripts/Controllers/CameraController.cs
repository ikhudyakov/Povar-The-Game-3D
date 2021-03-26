using UnityEngine;

namespace povar3d
{
    public sealed class CameraController : IExecute
    {
        private Transform PlayerTransform;
        private Transform CameraTransform;
        private Vector3 _offset;

        public CameraController(Transform player, Transform CameraTransform)
        {
            this.CameraTransform = CameraTransform;
            PlayerTransform = player;
            _offset = CameraTransform.position - PlayerTransform.position;
        }

        public void Follow()
        {
            CameraTransform.position = PlayerTransform.position + _offset;
        }

        public void Execute(float deltaTime)
        {
            Follow();
        }
    }
}