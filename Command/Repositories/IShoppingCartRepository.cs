using Command.Models;
using System.Collections.Generic;

namespace Command.Repositories
{
    public interface IShoppingCartRepository
    {
        (Product Product, int Quantity) Get(string productId);
        IEnumerable<(Product Product, int Quantity)> All();
        void Add(Product product);
        void RemoveAll(string productId);
        void IncreaseQuantity(string productId);
        void DecreaseQuantity(string productId);
    }
}