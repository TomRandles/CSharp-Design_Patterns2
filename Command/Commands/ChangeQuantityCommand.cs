using Command.Models;
using Command.Repositories;

namespace Command.Commands
{
    public partial class ChangeQuantityCommand : ICommand
    {

        private readonly Operation operation;
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        private readonly Product product;

        public ChangeQuantityCommand(Operation operation,
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            this.operation = operation;
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        public void Execute()
        {
            switch (operation)
            {
                case Operation.Decrease:
                    productRepository.IncreaseStockBy(product.ProductId, 1);
                    shoppingCartRepository.DecreaseQuantity(product.ProductId);
                    break;
                case Operation.Increase:
                    productRepository.DecreaseStockBy(product.ProductId, 1);
                    shoppingCartRepository.IncreaseQuantity(product.ProductId);
                    break;
            }
        }

        public bool CanExecute()
        {
            switch (operation)
            {
                case Operation.Decrease:
                    return shoppingCartRepository.Get(product.ProductId).Quantity != 0;
                case Operation.Increase:
                    return (productRepository.GetStockFor(product.ProductId) - 1) >= 0;
            }

            return false;
        }

        public void Undo()
        {
            switch (operation)
            {
                case Operation.Decrease:
                    productRepository.DecreaseStockBy(product.ProductId, 1);
                    shoppingCartRepository.IncreaseQuantity(product.ProductId);
                    break;
                case Operation.Increase:
                    productRepository.IncreaseStockBy(product.ProductId, 1);
                    shoppingCartRepository.DecreaseQuantity(product.ProductId);
                    break;
            }
        }
    }
}
