using System;
using System.Net.Http;
using Newtonsoft.Json;
using Strategy.Models;

namespace Strategy.Strategies.Invoice
{
    public class PrintInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);

                client.BaseAddress = new Uri("https://www.jzonesolutions.com/printService");

                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}
