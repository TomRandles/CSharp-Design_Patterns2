using Strategy.Models;

namespace Strategy.Strategies.SalesTax
{
    public class USASalesTaxStrategy : ISalesTaxStrategy
    {
        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public decimal GetTaxFor(Order order)
        {
            decimal taxCalc = 0m;

            switch(order.ShippingDetails.DestinationState)
            {
                case "California":
                    taxCalc = order.TotalPrice * 0.095m;
                    break;
                case "New York":
                    taxCalc = order.TotalPrice * 0.04m;
                    break;
                case "Texas":
                    taxCalc = order.TotalPrice * 0.045m;
                    break;
                default:
                    break;
            }
            return taxCalc;
        }
    }
}