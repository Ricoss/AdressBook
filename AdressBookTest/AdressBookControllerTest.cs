using AdressBook;
using AdressBook.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AdressBookTest
{
    public class AdressBookControllerTest
    {

        private readonly HttpClient _client;

        public AdressBookControllerTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task Get_WhenParametrIsCity_ReturnCity()
        {
            var adresbook = new Adress { Name = "Name", UserName = "Username", City = "City" };
            var adresbook1 = new Adress { Name = "Name1", UserName = "Username1", City = "Name" };
            var adresbook2 = new Adress { Name = "Name2", UserName = "Username2", City = "City" };
            Data.List.Add(adresbook);
            Data.List.Add(adresbook1);
            Data.List.Add(adresbook2);

            var response = await _client.GetAsync("/api/AdressBook/City");
            var forecast = JsonConvert.DeserializeObject<Adress[]>(await response.Content.ReadAsStringAsync());

            forecast.Length.ShouldBe(2);
            forecast[0].City.ShouldBe("City");
            forecast[1].City.ShouldBe("City");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            Data.List.Clear();
        }
    }
    
}
