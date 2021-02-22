using Command.Models;
using Command.Repositories;
using System;

namespace Command.Commands
{
    public class RemoveFromCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        private readonly Product product;

        public RemoveFromCartCommand(IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        public bool CanExecute()
        {
            if (product == null) return false;

            return shoppingCartRepository.Get(product.ProductId).Quantity > 0;
        }

        public void Execute()
        {
            if (product == null) return;

            var lineItem = shoppingCartRepository.Get(product.ProductId);

            productRepository.IncreaseStockBy(product.ProductId, lineItem.Quantity);

            shoppingCartRepository.RemoveAll(product.ProductId);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
