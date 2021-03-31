using System;

namespace Adapter.ReptileToAnimalAdapterExample
{
    public class ReptileChild : IChild
    {
        public void Cry()
        {
            Console.WriteLine("Reptile is crying ...:-(");        
        }

        public void Feed()
        {
            Console.WriteLine("Reptile is feeding :-)");
        }
    }
}