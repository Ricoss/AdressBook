using AdressBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdressBook.Services
{
    public interface IAddressService
    {
        public Task AddAdresAsync(string name, string street, int buldingNumber, string postCode, string city, string country);
        public Task AddAdresAsync(string name, string street, int buldingNumber, int premisesNumber, string postCode, string city, string country);
        public Task GetLastAddedAdresAsync();
        public Task<IEnumerable<Address>> GetAllAssync();
        public Task<IEnumerable<Address>> GetCityAsync(string city);
    }
}
