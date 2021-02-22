using Strategy.Strategies.Invoice;
using Strategy.Strategies.SalesTax;
using Strategy.Strategies.ShippingProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy.Models
{
    public class Order
    {
        // New sales tax strategy interface
        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        // New invoice strategy interface
        public IInvoiceStrategy InvoiceStrategy { get; set; }

        // New shipping strategy interface
        public IShippingProviderStrategy ShippingProviderStrategy { get; set; }

        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public IList<Payment> SelectedPayments { get; } = new List<Payment>();

        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();

        public decimal AmountDue => TotalPrice - FinalizedPayments.Sum(payment => payment.Amount);

        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);

        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;

        public ShippingDetails ShippingDetails { get; set; }

        public decimal GetTax(ISalesTaxStrategy salesTaxStrategy = default)
        {
            var taxStrategy = salesTaxStrategy ?? SalesTaxStrategy;

            return taxStrategy.GetTaxFor(this);
        }

        public void FinaliseOrder()
        {
            if (SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice) &&
                                     AmountDue > 0 &&
                                     ShippingStatus == ShippingStatus.WaitingForPayment)
            {
                InvoiceStrategy.Generate(this);
                ShippingStatus = ShippingStatus.ReadyForShippment;
            }
            else if (AmountDue > 0)
            {
                throw new Exception("Unable to finalise order");
            }

            ShippingProviderStrategy.Ship(this);
        }
    }
}