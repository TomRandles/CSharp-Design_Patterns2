using System;

namespace Adapter.ReptileToAnimalAdapterExample
{
    public class ReptileEgg
    {
        public ReptileEgg()
        {
            Console.WriteLine("Creating a new reptile egg");
        }
        public string Name { get; set; }

        public IChild Hatch()
        {
            Console.WriteLine("Hatching a new reptile egg");
            return new ReptileChild();
        }
    }
}