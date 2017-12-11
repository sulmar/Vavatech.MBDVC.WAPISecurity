using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MBDVC.WAPISecurity.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicAuthenticationTest().Wait();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

        private static async Task BasicAuthenticationTest()
        {
            string username = "user";
            string password = "P@ssw0rd";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59197/");

                string parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

                var authenticationValue = new AuthenticationHeaderValue("Basic", parameter);

                client.DefaultRequestHeaders.Authorization = authenticationValue;

                var response = await client.GetAsync("api/products");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(result);
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(response.ReasonPhrase);
                }


            }

        }
    }
}
