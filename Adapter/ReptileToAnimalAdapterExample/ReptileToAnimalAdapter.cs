namespace Adapter.ReptileToAnimalAdapterExample
{
    public class ReptileToAnimalAdapter : IAnimal
    {
        private readonly Reptile reptile;

        public ReptileToAnimalAdapter(Reptile reptile)
        {
            this.reptile = reptile;
            System.Console.WriteLine("Creating a new Reptile To Animal Adapter");
        }

        public IChild GiveBirth()
        {
            var egg = reptile.LayEgg();
            var child = egg.Hatch();

            return child;
        }
    }
}