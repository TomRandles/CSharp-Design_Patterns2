using Strategy.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy.Models
{
    public class Order
    {
        // New sales tax strategy interface
        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public IList<Payment> SelectedPayments { get; } = new List<Payment>();

        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();

        public decimal AmountDue => TotalPrice - FinalizedPayments.Sum(payment => payment.Amount);

        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);

        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;

        public ShippingDetails ShippingDetails { get; set; }

        public decimal GetTax()
        {
            if (SalesTaxStrategy == null)
                throw new NullReferenceException("Sales tax strategy object not set");

            return SalesTaxStrategy.GetTaxFor(this);
        }
    }
}