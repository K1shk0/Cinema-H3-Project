using Cinem2026.Repo;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2026.Repo.Repositories
{
    public class PersonRepositories:IPersonRepositories
    {
        private readonly DatabaseContext context;
        public PersonRepositories(DatabaseContext d) 
        {
            context = d;
        }
        // create 
        // get
        #region
        
        // using my persons list

        //public async Task<List<Person>> GetAllPersons()
        //{
        //    // Guard against null context
        //    if (context == null)
        //    {
        //        return await Task.FromResult(new List<Person>());
        //    }

        //    // Materialize the Persons collection to a List in a safe, synchronous manner
        //    // and return it as an awaited Task to satisfy the async contract.
        //    var personsList = await context.Persons?.ToListAsync();
        //    return personsList;
        //}

        public Task<Person> CreatePerson()
        {
            throw new NotImplementedException();
        }
        #endregion

        //public async Task<List<Person>> GetAllPersons()
        //{
        //    return await context.Persons.ToListAsync();
        //}

        public async Task<Person> CreatePerson(Person person)
        {
            //context.Persons.Add(new Person { name = "New Person", age = 20 });
            context.Persons.Add(person);
            await context.SaveChangesAsync();
            return person;
        }

        //public Task<List<Person>> GetAllPersons()11112212111112
        //{ // hente alt det gøres med ToLIstAsync()
        //    throw new NotImplementedException();
        //}

        public async Task<List<Person>> GetAllPersons()
        {
            return await context.Persons.ToListAsync();
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            return null;
        }
        public async Task<bool> DeletePersons(int personid)
        {
            var search = await context.Persons.FirstOrDefaultAsync(obj => obj.Id == personid);
            return search != null ? true : false;
        }

        public Task<List<Person>> DeletePersons(Person person)
        {
            throw new NotImplementedException();
        }

        Task<List<Person>> IPersonRepositories.DeletePersons(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
