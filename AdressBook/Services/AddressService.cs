using AdressBook.Models;
using AdressBook.Repozytories;
using System.Threading.Tasks;

namespace AdressBook.Services
{
    public class AddressServicen : IAddressService
    {
        private readonly IAddressRepozytories _addressRepozytories;
        public AddressServicen(IAddressRepozytories addressRepozytories)
        {
            _addressRepozytories = addressRepozytories;
        }

        public async Task AddAdresAsync(string name, string street, int buldingNumber, string postCode, string city, string country)
        {
            var address = new Address(name, street, buldingNumber, postCode, city, country);
            await _addressRepozytories.AddAssync(address);
        }

        public async Task AddAdresAsync(string name, string street, int buldingNumber, int premisesNumber, string postCode, string city, string country)
        {
            var address = new Address(name, street, buldingNumber, buldingNumber, postCode, city, country);
            await _addressRepozytories.AddAssync(address);
        }

        public async Task<Address> GetCityAsync(string city)
            =>await _addressRepozytories.GetCityAssync(city);

        public async Task GetLastAddedAdresAsync()
        {
            var adres = _addressRepozytories.GetAllAssync();
            //TODO 

        }
    }
}
