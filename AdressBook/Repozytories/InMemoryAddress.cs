using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Repozytories
{
    public class InMemoryAddress : IAddressRepozytories
    {
        private static ISet<Address> _addres = new HashSet<Address>
        {
            new Address ("nazwa1", "ulica1",1,"00-000","miasto1","kraj1"),
            new Address ("nazwa2", "ulica2",2,"00-000","miasto1","kraj1"),
            new Address ("nazwa3", "ulica3",1,"00-000","miasto2","kraj1"),
            new Address ("nazwa4", "ulica1",2,"00-000","miasto3","kraj2"),
            new Address ("nazwa4", "ulica1",2,0,"00-000","miasto3","kraj2"),
        };
        public async Task AddAssync(Address address)
        {
            _addres.Add(address);
            await Task.CompletedTask;
        }
        public async Task<Address> GetAssync(Guid id)
           => await Task.FromResult(_addres.FirstOrDefault(x => x.Id == id));
        public async Task<Address> GetCityAssync(string city)
           => await Task.FromResult(_addres.FirstOrDefault(x => x.City == city.ToLower()));

        public async Task<IEnumerable<Address>> GetAllAssync()
           => await Task.FromResult(_addres.ToList());

        public async Task UpdataAssync(Address address)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAssync(Guid id)
        {
            var addresId = await(GetAssync(id));
            _addres.Remove(addresId);
            await Task.CompletedTask;
        }

    }
}
