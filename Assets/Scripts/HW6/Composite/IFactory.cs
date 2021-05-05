namespace hw6
{
    internal interface IFactory <T>
    {
        T Create(string path);
    }
}