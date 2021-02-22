using Command.Models;
using System.Collections.Generic;

namespace Command.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public Dictionary<string, (Product Product, int Quantity)> LineItems
            = new Dictionary<string, (Product Product, int Quantity)>();

        public IEnumerable<(Product Product, int Quantity)> All()
        {
            return LineItems.Values;
        }

        public (Product Product, int Quantity) Get(string productId)
        {
            if (LineItems.ContainsKey(productId))
            {
                return LineItems[productId];
            }

            return (default, default);
        }

        public void Add(Product product)
        {
            if (LineItems.ContainsKey(product.ProductId))
            {
                IncreaseQuantity(product.ProductId);
            }
            else
            {
                LineItems[product.ProductId] = (product, 1);
            }
        }

        public void DecreaseQuantity(string productId)
        {
            if (LineItems.ContainsKey(productId))
            {
                var lineItem = LineItems[productId];

                if (lineItem.Quantity == 1)
                {
                    LineItems.Remove(productId);
                }
                else
                {
                    LineItems[productId] = (lineItem.Product, lineItem.Quantity - 1);
                }
            }
            else
            {
                throw new KeyNotFoundException($"Product with article id {productId} not in cart, please add first");
            }
        }

        public void IncreaseQuantity(string productId)
        {
            if (LineItems.ContainsKey(productId))
            {
                var lineItem = LineItems[productId];
                LineItems[productId] = (lineItem.Product, lineItem.Quantity + 1);
            }
            else
            {
                throw new KeyNotFoundException($"Product with product id {productId} not in cart, please add first");
            }
        }

        public void RemoveAll(string productId)
        {
            LineItems.Remove(productId);
        }
    }
}
