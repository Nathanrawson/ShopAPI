using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumerApp.cs
{
    public class ShopApiTest
    {
        string BaseUrl = "https://localhost:44362/api/";

        public void PrintAllProducts()
        {
            HttpClient client = new HttpClient();

            var result = client.GetAsync($"{BaseUrl}products").Result;

            var resultString = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(resultString);
        }

        public void PrintAllCategories()
        {
            HttpClient client = new HttpClient();

            var result = client.GetAsync($"{BaseUrl}category").Result;

            var resultString = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(resultString);
        }

        public void PrintProductByCategory(int id)
        {
            HttpClient client = new HttpClient();

            var result = client.GetAsync($"{BaseUrl}products/Category?categoryId={id}").Result;

            var resultString = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(resultString);
        }
    }
}
