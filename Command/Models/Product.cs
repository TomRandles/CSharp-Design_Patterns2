namespace Command.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product()
        {

        }

        public Product(string id, string name, decimal price)
        {
            ProductId = id;
            Name = name;
            Price = price;
        }
    }
}
