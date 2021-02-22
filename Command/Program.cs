using Command.Commands;
using Command.Repositories;
using ShoppingCart.Business.Commands;
using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shopping car - command pattern");

            // Two data stores - cart and product
            var shoppingCartRepository = new ShoppingCartRepository();
            var productsRepository = new ProductsRepository();

            var product = productsRepository.FindBy("SM7B");

            // Introduce command pattern to handle shopping cart commands

            var addToCartCommand = new AddToCartCommand(shoppingCartRepository,
                                               productsRepository,
                                               product);

            var increaseQuantityCmd = new ChangeQuantityCommand(Operation.Increase,
                                                                shoppingCartRepository,
                                                                productsRepository,
                                                                product);

            var commandManager = new CommandManager();

            commandManager.Invoke(addToCartCommand);
            commandManager.Invoke(increaseQuantityCmd);
            commandManager.Invoke(increaseQuantityCmd);
            commandManager.Invoke(increaseQuantityCmd);
            commandManager.Invoke(increaseQuantityCmd);
            
            PrintCart(shoppingCartRepository);

            commandManager.Undo();

            PrintCart(shoppingCartRepository);
        }

        private static void PrintCart(ShoppingCartRepository shoppingCartRepository)
        {
            if (shoppingCartRepository.LineItems.Count == 0 )
                Console.WriteLine("Shopping cart empty!");

            foreach (var item in shoppingCartRepository.LineItems)
            {
                Console.WriteLine($"Product: {item.Key}, quantity: {item.Value.Quantity}");
            }
        }
    }
}
