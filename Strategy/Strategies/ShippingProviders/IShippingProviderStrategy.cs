using Strategy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Strategies.ShippingProviders
{
    public interface IShippingProviderStrategy
    {
        public void Ship(Order order);
    }
}
