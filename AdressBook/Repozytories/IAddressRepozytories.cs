using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdressBook.Repozytories
{
    public interface IAddressRepozytories
    {
        Task AddAssync(Address address);
        Task<Address> GetAssync(Guid id);
        Task<IEnumerable<Address>> GetCityAssync(string city);
        Task<IEnumerable<Address>> GetAllAssync();
        Task UpdataAssync (Address adress);
        Task DeleteAssync(Guid id);
    }
}
