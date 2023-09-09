using AdressBook.Commands;
using AdressBook.Models;
using AdressBook.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdressBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressService _adressService;
        public AddressBookController(IAddressService adressService)
        {
            _adressService = adressService;
        }
        [HttpPost]
        public async Task Post([FromBody] HomeAddress addressBook)
        {
            await _adressService.AddAdresAsync(addressBook.Name, addressBook.Street, addressBook.BuldingNumber, addressBook.PostCode, addressBook.City, addressBook.Country);
        }
        [Route("BlockAddress")]
        [HttpPost]
        public async Task Post([FromBody] BlockAddress addressBook)
        {
            await _adressService.AddAdresAsync(addressBook.Name, addressBook.Street, addressBook.BuldingNumber, addressBook.PremisesNumber, addressBook.PostCode, addressBook.City, addressBook.Country);
        }
        [HttpGet("{city}")]
        public async Task<Address> Get(string city)
        => await _adressService.GetCityAsync(city);
        [Route("GetLastAddedAdres")]
        [HttpGet]
        public async Task Get()
        {

        }
        [Route("GetAllAddress")]
        [HttpGet]
        public async Task<IEnumerable<Address>> GetAll()
        => await _adressService.GetAllAssync();

    }
}
