using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Repozytories
{
    public class InMemoryAdress : IAdressRepozytories
    {
        private static ISet<Adress> _addres = new HashSet<Adress>
        {
            new Adress ("nazwa1", "ulica1",1,"00-000","miasto1","kraj1"),
            new Adress ("nazwa2", "ulica2",2,"00-000","miasto1","kraj1"),
            new Adress ("nazwa3", "ulica3",1,"00-000","miasto2","kraj1"),
            new Adress ("nazwa4", "ulica1",2,"00-000","miasto3","kraj2"),
            new Adress ("nazwa4", "ulica1",2,0,"00-000","miasto3","kraj2"),
        };
        public async Task AddAssync(Adress adress)
        {
            _addres.Add(adress);
            await Task.CompletedTask;
        }
        public async Task<Adress> GetAssync(Guid id)
           => await Task.FromResult(_addres.FirstOrDefault(x => x.Id == id));
        public async Task<Adress> GetCityAssync(string city)
           => await Task.FromResult(_addres.FirstOrDefault(x => x.City == city.ToLower()));

        public async Task<IEnumerable<Adress>> GetAllAssync()
           => await Task.FromResult(_addres.ToList());

        public async Task UpdataAssync(Adress adress)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAssync(Guid id)
        {
            var addresid = await(GetAssync(id));
            _addres.Remove(addresid);
            await Task.CompletedTask;
        }

    }
}
