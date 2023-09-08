using AdressBook.Commands;
using AdressBook.Models;
using AdressBook.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdressBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdressBookController : ControllerBase
    {
        private readonly IAdressService _adressService;
        public AdressBookController(IAdressService adressService)
        {
            _adressService = adressService;
        }
        [HttpPost]
        public async Task Post([FromBody] HomeAddress adressBook)
        {
            await _adressService.AddAdresAsync(adressBook.Name, adressBook.Street, adressBook.BuldingNumber, adressBook.PostCode, adressBook.City, adressBook.Country);
        }
        [Route("BlockAddress")]
        [HttpPost]
        public async Task Post([FromBody] BlockAddress adressBook)
        {
            await _adressService.AddAdresAsync(adressBook.Name, adressBook.Street, adressBook.BuldingNumber, adressBook.PremisesNumber, adressBook.PostCode, adressBook.City, adressBook.Country);
        }
        [HttpGet("{city}")]
        public async Task<Adress> Get(string city)
        => await _adressService.GetCityAsync(city);
        [Route("GetLastAddedAdres")]
        [HttpGet]
        public async Task Get()
        {

        }

    }
}
