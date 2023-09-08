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
        [HttpGet("{city}")]
        public async Task<Adress> Get(string city)
        =>  await _adressService.GetCityAsync(city);   
    }
}
