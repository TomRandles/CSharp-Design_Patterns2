using Strategy.Models;
using Strategy.Strategies.SalesTax;
using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy pattern - ch 1");

            // Sweden has two tax rates - one within Sweden and no tax outside Sweden
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            order.LineItems.Add(new Item("CSharp In Depth", "C# In Depth", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("Consulting", "Building a website", 100m, ItemType.Service), 1);

            // Set new sales tax strategy in accordance with country

            if (order.ShippingDetails.DestinationCountry == "Sweden")
                order.SalesTaxStrategy = new SwedenSalesTaxStrategy();

            if (order.ShippingDetails.DestinationCountry == "USA")
                order.SalesTaxStrategy = new USASalesTaxStrategy();


            Console.WriteLine($"Tax details {order.GetTax()}");

        }
    }
}
