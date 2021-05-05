namespace hw6
{
    public class CompositeFactory : IFactory<CompositeFactory>
    {
        private MagFactory _magFactory = new MagFactory();
        private InfantryFactory _infantryFactory = new InfantryFactory();

        public CompositeFactory Create(string path)
        {
            _magFactory.Create(path);
            _infantryFactory.Create(path);
            return this;
        }
    }
}