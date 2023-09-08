using AdressBook.Models;
using System.Threading.Tasks;

namespace AdressBook.Services
{
    public interface IAddressService
    {
        public Task AddAdresAsync(string name, string street, int buldingNumber, string postCode, string city, string country);
        public Task AddAdresAsync(string name, string street, int buldingNumber, int premisesNumber, string postCode, string city, string country);
        public Task GetLastAddedAdresAsync();
        public Task<Address> GetCityAsync(string city);
    }
}
