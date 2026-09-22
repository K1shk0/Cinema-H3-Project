using Cinema2026.Repo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2026.Repo.Interfaces
{
    public interface IPersonRepositories
    {
        public Task<List<Person>> DeletePersons(int personId);
        public Task<List<Person>> GetAllPersons();
        public Task<Person> CreatePerson(Person person);
        public Task<Person> UpdatePerson(Person person);
    }
}
