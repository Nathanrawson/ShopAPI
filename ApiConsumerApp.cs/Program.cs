using System;
using System.Net.Http;

namespace ApiConsumerApp.cs
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            var shopApiTest = new ShopApiTest();

            Console.WriteLine("Here is getting all products\n");

            shopApiTest.PrintAllProducts();

            Console.WriteLine("\nHere is getting all categories\n");

            shopApiTest.PrintAllCategories();

            Console.WriteLine("\nHere is getting all products with category id 1\n");

            shopApiTest.PrintProductByCategory(1);

        }
    }
}
