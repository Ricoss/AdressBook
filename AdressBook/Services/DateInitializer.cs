using AdressBook.Models;
using AdressBook.Repozytories;
using AdressBook.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdressBook.Services
{
    public class DateInitializer : IDateInitializer
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<DateInitializer> _logger;
        public DateInitializer(IAddressService addressServicen, ILogger<DateInitializer> logger)
        {
            _addressService = addressServicen;
            _logger = logger;
        }
        public async Task AddAddressAsync()
        {
            _logger.LogInformation("data initialization has begun");
            var tasks = new List<Task>();
            for (var i = 1; i <= 2; i++)
            {
            tasks.Add(_addressService.AddAdresAsync($"Name{i}", $"Stret1", i, "19-200", "Bełda", "Polend"));
            tasks.Add(_addressService.AddAdresAsync($"Name{i}", $"Stret2", i, "76-211", "Bałamątek", "Polend"));
            tasks.Add(_addressService.AddAdresAsync($"Name{i}", $"Stret3", i,i+1, "62-641", "Adamin", "Polend"));
            tasks.Add(_addressService.AddAdresAsync($"Name{i}", $"Stret4", i,i+1, "62-652", "Niwki", "Polend"));
            }
            await Task.WhenAll(tasks);
            _logger.LogInformation("data initialization has end");
        }
    }
}

