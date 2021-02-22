using Command.Models;
using System.Collections.Generic;
using System.Linq;

namespace Command.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        private Dictionary<string, (Product Product, int Stock)> products { get; }

        public ProductsRepository()
        {
            products = new Dictionary<string, (Product Product, int Stock)>();

            Add(new Product("EOSR1", "Canon EOS R", 1099), 2);
            Add(new Product("EOS70D", "Canon EOS 70D", 699), 1);
            Add(new Product("ATOMOSNV", "Atomos Ninja V", 799), 0);
            Add(new Product("SM7B", "Shure SM7B", 399), 5);
        }

        public void Add(Product product, int stock)
        {
            products[product.ProductId] = (product, stock);
        }

        public void DecreaseStockBy(string productId, int amount)
        {
            if (!products.ContainsKey(productId)) return;

            products[productId] = 
                (products[productId].Product, products[productId].Stock - amount);
        }

        public void IncreaseStockBy(string productId, int amount)
        {
            if (!products.ContainsKey(productId)) return;

            products[productId] = 
                (products[productId].Product, products[productId].Stock + amount);
        }

        public IEnumerable<Product> All()
        {
            return products.Select(x => x.Value.Product);
        }

        public int GetStockFor(string productId)
        {
            if (products.ContainsKey(productId))
            {
                return products[productId].Stock;
            }

            return 0;
        }

        public Product FindBy(string productId)
        {
            if (products.ContainsKey(productId))
            {
                return products[productId].Product;
            }

            return null;
        }
    }

    public interface IProductRepository
    {
        Product FindBy(string productId);
        int GetStockFor(string productId);
        IEnumerable<Product> All();
        void DecreaseStockBy(string productId, int amount);
        void IncreaseStockBy(string productId, int amount);
    }
}
