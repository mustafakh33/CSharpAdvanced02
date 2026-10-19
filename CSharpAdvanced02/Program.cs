using CSharpAdvanced02.Data;
using CSharpAdvanced02.Models;
using System.Security.Cryptography.X509Certificates;

namespace CSharpAdvanced02
{
    public class Program
    {
        // Func<Product, bool> receives a Product
        // and returns true or false to determine whether it matches.
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        // Action<Product> receives a Product and performs an action on it.
        static void PrintReport(List<Product> products, Action<Product> printAction)
        {
            foreach (Product product in products)
            {
                printAction(product);
            }
        }

        static void Main(string[] args)
        {

            List<Product> catalog = ProductCatalog.GetProducts();

            // Search 1: Electronics products
            List<Product> electronics = SearchProducts(
                catalog,
                p => p.Category == "Electronics"
            );

            Console.WriteLine("--- Electronics ---");

            foreach (Product product in electronics)
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
                );
            }

            // Search 2: Products cheaper than $50
            List<Product> under50 = SearchProducts(
                catalog,
                p => p.Price < 50
            );

            Console.WriteLine("\n--- Under $50 ---");

            foreach (Product product in under50)
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
                );
            }

            // Search 3: Products that are in stock
            List<Product> inStock = SearchProducts(
                catalog,
                p => p.Stock > 0
            );

            Console.WriteLine("\n--- In Stock ---");

            foreach (Product product in inStock)
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
                );
            }

            // Search 4: Clothing products under $100
            List<Product> clothingUnder100 = SearchProducts(
                catalog,
                p => p.Category == "Clothing" && p.Price < 100
            );

            Console.WriteLine("\n--- Clothing Under $100 ---");

            foreach (Product product in clothingUnder100)
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
                );
            }

            Console.WriteLine();

            // Print a short report using Action<Product>
            Console.WriteLine("--- Short Report ---");

            PrintReport(catalog, p =>
            {
                Console.WriteLine($"{p.Name} - ${p.Price}");
            });

            // Print a detailed report using Action<Product>
            Console.WriteLine("\n--- Detailed Report ---");

            PrintReport(catalog, p =>
            {
                Console.WriteLine(
                    $"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"
                );
            });

        }
    }
}
