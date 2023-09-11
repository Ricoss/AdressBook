using AdressBook.Commands;
using AdressBook.Models;
using AdressBook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdressBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressService _adressService;
        private readonly ILogger<AddressBookController> _logger;
        public AddressBookController(IAddressService adressService, ILogger<AddressBookController> logger)
        {
            _adressService = adressService;
            _logger = logger;
        }
        [HttpPost]
        public async Task Post([FromBody] HomeAddress addressBook)
        {
            try
            {
                var message = $"Add {addressBook.Name}, {addressBook.Street}, {addressBook.BuldingNumber}, {addressBook.PostCode}, {addressBook.City}, {addressBook.Country}.";
                await _adressService.AddAdresAsync(addressBook.Name, addressBook.Street, addressBook.BuldingNumber, addressBook.PostCode, addressBook.City, addressBook.Country);
                _logger.LogInformation(message);
                Ok();
            }
            catch (Exception ex)
            {
                var message = $"Post method reported {ex}.";
                _logger.LogInformation(message);
                BadRequest(ex);
            }
        }

        [Route("BlockAddress")]
        [HttpPost]
        public async Task Post([FromBody] BlockAddress addressBook)
        {
            try
            {
                var message = $"Add {addressBook.Name}, {addressBook.Street}, {addressBook.BuldingNumber}, {addressBook.PremisesNumber}, {addressBook.PostCode}, {addressBook.City}, {addressBook.Country}.";
                await _adressService.AddAdresAsync(addressBook.Name, addressBook.Street, addressBook.BuldingNumber, addressBook.PremisesNumber, addressBook.PostCode, addressBook.City, addressBook.Country);
                _logger.LogInformation(message);
                Ok();
            }
            catch (Exception ex)
            {
                var message = $"Post method reported {ex}.";
                _logger.LogInformation(message);
                BadRequest(ex);
            }
        }
        [HttpGet("{city}")]
        public async Task<IEnumerable<Address>> Get(string city)
        {
            var message = $"Addres in city {city}.";
            var q =  await _adressService.GetCityAsync(city);
            _logger.LogInformation(message);
            return q;
        }
        [Route("GetLastAddedAdres")]
        [HttpGet]
        public async Task<Address> Get()
        {
            var message = $"Last added address downloaded.";
            var q = await _adressService.GetLastAddedAdresAsync();
            _logger.LogInformation(message);
            return q;
        }
        [Route("GetAllAddress")]
        [HttpGet]
        public async Task<IEnumerable<Address>> GetAll()
        {
        var message = $"All address downloaded.";
        var q = await _adressService.GetAllAssync();
        _logger.LogInformation(message);
        return q;
        }
    }
}
