namespace povar3d
{
    internal interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}