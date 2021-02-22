using Strategy.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Strategy.Strategies.ShippingProviders
{
    public class SwedishShippingProvider : IShippingProviderStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                // To do - call swedish shipping api using client

                Console.WriteLine("Shipped using Swedish state shipping provider");
            }
        }
    }
}
