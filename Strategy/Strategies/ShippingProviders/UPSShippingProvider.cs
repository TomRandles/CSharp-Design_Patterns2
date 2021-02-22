using Strategy.Models;
using System;
using System.Net.Http;

namespace Strategy.Strategies.ShippingProviders
{
    public class UPSShippingProvider : IShippingProviderStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                // To do - call UPS shipping api using client

                Console.WriteLine("Shipped using UPS shipping provider");
            }
        }
    }
}
