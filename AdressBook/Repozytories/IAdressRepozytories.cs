using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdressBook.Repozytories
{
    public interface IAdressRepozytories
    {
        Task AddAssync(Adress adress);
        Task<Adress> GetAssync(Guid id);
        Task<Adress> GetCityAssync(string city);
        Task<IEnumerable<Adress>> GetAllAssync();
        Task UpdataAssync (Adress adress);
        Task DeleteAssync(Guid id);
    }
}
