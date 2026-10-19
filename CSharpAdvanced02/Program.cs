using CSharpAdvanced02.Data;
using CSharpAdvanced02.Models;

namespace CSharpAdvanced02
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = ProductCatalog.GetProducts();

            Console.WriteLine($"Total Products: {catalog.Count}");
        }
    }
}
