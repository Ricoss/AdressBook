using AdressBook.Models;
using AdressBook.Repozytories;
using AdressBook.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdressBook.Services
{
    public class DateInitializer : IDateInitializer
    {
        private readonly IAddressService _addressService;
        public DateInitializer(IAddressService addressServicen)
        {
            _addressService = addressServicen;
        }
        public async Task AddAddressAsync()
        {   
            var tasks = new List<Task>();
            for (var i = 1; i <= 2; i++)
            {
            tasks.Add(_addressService.AddAdresAsync($"Name{i}", $"Stret{i}", i, "19-200", "Bełda", "Polend"));
            tasks.Add(_addressService.AddAdresAsync($"Name{i}", $"Stret{i}", i, "76-211", "Bałamątek", "Polend"));
            tasks.Add(_addressService.AddAdresAsync($"Name{i}", $"Stret{i}", i,i+1, "62-641", "Adamin", "Polend"));
            tasks.Add(_addressService.AddAdresAsync($"Name{i}", $"Stret{i}", i,i+1, "62-652", "Niwki", "Polend"));
            }
            await Task.WhenAll(tasks);
        }
    }
}

