using DemoDatabaseFirst.Model;

namespace DemoDatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyShopContext myShopContext = new MyShopContext();
            var product = from p in myShopContext.Products
                          select new Product
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName
                          };
            Console.WriteLine("Product List:");
            foreach (var p in product)
            {
                Console.WriteLine($"Product ID: {p.ProductId}, ProductName: {p.ProductName}");
            }
        }
    }
}
