using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MBDVC.WAPISecurity.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PrincipalTest();

            BasicAuthenticationTest().Wait();

            Console.WriteLine("Press any key to exit.");

        

            Console.ReadKey();

        }


        private static void PrincipalTest()
        {
            Claim claim = new Claim("blabla", "1234");

            Claim claimName = new Claim(ClaimTypes.Name, "marcin");
            Claim claimEmail = new Claim(ClaimTypes.Email, "marcin.sulecki@gmail.com");
            Claim claimPhone = new Claim(ClaimTypes.MobilePhone, "609851649");
            Claim claimRole1 = new Claim(ClaimTypes.Role, "admin");
            Claim claimRole2 = new Claim(ClaimTypes.Role, "user");

            var claims = new List<Claim> { claim, claimName, claimEmail, claimPhone, claimRole1, claimRole2 };

            IIdentity identity = new ClaimsIdentity(claims, "Basic");

            IPrincipal principal = new ClaimsPrincipal(identity);


            Thread.CurrentPrincipal = principal;

            if (Thread.CurrentPrincipal.IsInRole("admin"))
            {
                Console.WriteLine("Jesteś adminem!");
            }
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
