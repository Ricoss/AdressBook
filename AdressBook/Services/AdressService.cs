using AdressBook.Models;
using AdressBook.Repozytories;
using System.Threading.Tasks;

namespace AdressBook.Services
{
    public class AdressServicen : IAdressService
    {
        private readonly IAdressRepozytories _adressRepozytories;
        public AdressServicen(IAdressRepozytories adressRepozytories)
        {
            _adressRepozytories = adressRepozytories;
        }
        public async Task AddAdresAsync(string name, string street, int buldingNumber, string postCode, string city, string country)
        {
            var adres = new Adress(name, street, buldingNumber, postCode, city, country);
            await _adressRepozytories.AddAssync(adres);
        }

        public async Task AddAdresAsync(string name, string street, int buldingNumber, int premisesNumber, string postCode, string city, string country)
        {
            var adres = new Adress(name, street, buldingNumber, buldingNumber, postCode, city, country);
            await _adressRepozytories.AddAssync(adres);
        }

        public async Task GetCityAsync(string city)
           => await _adressRepozytories.GetCityAssync(city);
        

        public async Task GetLastAddedAdresAsync()
        {
            var adres = _adressRepozytories.GetAllAssync();
            //TODO 
                
        }
    }
}
