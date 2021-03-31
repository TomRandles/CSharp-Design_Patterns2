using Adapter.ReptileToAnimalAdapterExample;
using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the world of reptiles!!");

            var lizard = new Reptile();
      
            // The ChildCreator.CreateChild is a generic means of creating new animals of different varieties
            // The appropriate adaptor will be passed to the CreateChild method.
            var child = ChildCreator.CreateChild(new ReptileToAnimalAdapter(lizard));
            child.Cry();
            child.Feed();

        }
    }
}