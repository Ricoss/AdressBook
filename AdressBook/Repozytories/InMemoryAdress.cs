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
            new Adress ("Nazwa1", "ulica1",1,"00-000","Miasto1","Kraj1"),
            new Adress ("Nazwa2", "ulica2",2,"00-000","Miasto1","Kraj1"),
            new Adress ("Nazwa3", "ulica3",1,"00-000","Miasto2","Kraj1"),
            new Adress ("Nazwa4", "ulica1",2,"00-000","Miasto3","Kraj2"),
            new Adress ("Nazwa4", "ulica1",2,0,"00-000","Miasto3","Kraj2"),
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
           => await Task.FromResult(_addres);

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
