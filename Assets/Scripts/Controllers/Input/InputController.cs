namespace povar3d {
    public class InputController : IExecute
    {
        private float _horizontal;
        private float _vertical;

        public float Horizontal { get => _horizontal; set => _horizontal = value; }
        public float Vertical { get => _vertical; set => _vertical = value; }

        public void Execute(float deltaTime)
        {

        }
    }
}