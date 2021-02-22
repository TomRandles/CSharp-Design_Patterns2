using Command.Repositories;
using System;
using System.Linq;

namespace Command.Commands
{
    public class RemoveAllFromCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public RemoveAllFromCartCommand(IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        public bool CanExecute()
        {
            return shoppingCartRepository.All().Any();
        }

        public void Execute()
        {
            var items = shoppingCartRepository.All().ToArray(); // Make a local copy

            foreach (var lineItem in items)
            {
                productRepository.IncreaseStockBy(lineItem.Product.ProductId, lineItem.Quantity);

                shoppingCartRepository.RemoveAll(lineItem.Product.ProductId);
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
