using Strategy.Models;
using Strategy.Strategies.Invoice;
using Strategy.Strategies.SalesTax;
using Strategy.Strategies.ShippingProviders;
using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter country of origin:");
            var origin = Console.ReadLine().Trim();

            Console.WriteLine("Enter destination country:");
            var destination = Console.ReadLine().Trim();

            Console.WriteLine("Choose a shipping service provider");
            Console.WriteLine("1. Default shipping provider - DHL");
            Console.WriteLine("2. Shipping provider - Swedish state");
            Console.WriteLine("3. Shipping provider - UPS");

            var shippingCompany = Console.ReadLine().Trim();
            var shippingNo = Convert.ToInt32(shippingCompany);

            Console.WriteLine("Choose an invoice delivery option:");
            Console.WriteLine("1. File");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Print");

            var invoiceType = Console.ReadLine().Trim();
            var invoiceTypeNo = Convert.ToInt32(invoiceType);


            // Sweden has two tax rates - one within Sweden and no tax outside Sweden
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = origin,
                    DestinationCountry = destination
                },
                SalesTaxStrategy = GetSalesTaxStrategy(origin),
                InvoiceStrategy = GetInvoiceStrategy(invoiceTypeNo),
                ShippingProviderStrategy = GetShippingProvider(shippingNo)
            };


            order.LineItems.Add(new Item("CSharp In Depth", "C# In Depth", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("Consulting", "Building a website", 100m, ItemType.Service), 1);


            Console.WriteLine($"Tax details {order.GetTax()}");

            // Set payment invoice 
            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice
            });



            order.FinaliseOrder();
        }

        private static IShippingProviderStrategy GetShippingProvider(int shippingNo)
        {
            IShippingProviderStrategy shippingProvider = default;
            if (shippingNo == 1)
                shippingProvider = new DefaultShippingProvider();
            else if (shippingNo == 2)
                shippingProvider = new SwedishShippingProvider();
            else if (shippingNo == 3)
                shippingProvider = new UPSShippingProvider();
            else
                throw new Exception("Unknown Shipping provider");

            return shippingProvider;
        }

        private static IInvoiceStrategy GetInvoiceStrategy(int invoiceTypeNo)
        {
            IInvoiceStrategy invoiceStrategy = default;
            if (invoiceTypeNo == 1)
                invoiceStrategy = new FileInvoiceStrategy();
            else if (invoiceTypeNo == 2)
                invoiceStrategy = new EmailInvoiceStrategy();
            else if (invoiceTypeNo == 3)
                invoiceStrategy = new PrintInvoiceStrategy();
            else
                throw new Exception("Unknown invoice strategy");

            return invoiceStrategy;
        }

        private static ISalesTaxStrategy GetSalesTaxStrategy(string origin)
        {
            ISalesTaxStrategy salesTaxStrategy = default;
            // Set new sales tax strategy in accordance with country
            if (origin.ToLower() == "sweden")
            {
                salesTaxStrategy = new SwedenSalesTaxStrategy();
            }
            else if (origin.ToLower() == "usa")
            {
                salesTaxStrategy = new USASalesTaxStrategy();
            }
            else
                throw new Exception("Unsupported country sales tax");

            return salesTaxStrategy;
        }
    }
}