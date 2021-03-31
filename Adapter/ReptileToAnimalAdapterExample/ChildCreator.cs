namespace Adapter.ReptileToAnimalAdapterExample
{
    public static class ChildCreator
    {
        public static IChild CreateChild(IAnimal animal)
        {
            return animal.GiveBirth();
        }
    }
}