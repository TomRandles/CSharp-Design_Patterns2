using Command.Models;
using Command.Repositories;
using Command.Commands;

namespace ShoppingCart.Business.Commands
{
    public class AddToCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        private readonly Product product;

        public AddToCartCommand(IShoppingCartRepository shoppingCartRepository,
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

            return productRepository.GetStockFor(product.ProductId) > 0;
        }

        public void Execute()
        {
            if (product == null) return;

            productRepository.DecreaseStockBy(product.ProductId, 1);

            shoppingCartRepository.Add(product);
        }

        public void Undo()
        {
            if (product == null) return;

            var lineItem = shoppingCartRepository.Get(product.ProductId);

            productRepository.IncreaseStockBy(product.ProductId, lineItem.Quantity);

            shoppingCartRepository.RemoveAll(product.ProductId);
        }
    }
}
