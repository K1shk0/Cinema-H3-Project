using System;
using System.Collections.Generic;
using System.Text;
using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.EntityFrameworkCore;
using Cinema2026.Repo.Repositories;

namespace Cinema2026.Test.RepositoriesTest
{
    public class PersonRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext> options;
        private readonly DatabaseContext context;
        private readonly IGenericRepositories<Person> repository;

        public PersonRepositoryTest()
        {
            //Datastore - En liste de objekter I gerne vil have skal være jeres "database" i testen.
            //Package simulerer data
            options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            context = new DatabaseContext(options);
            repository = new GenericRepositories<Person>(context);
            //1) seed vores database SeedData();
            //2) eller seed den senere
            //3) husk savechanges()

            Person person1 = new Person() { Id = 1, name = "John Doe", age = 30, email = "john.doe@example.com" };
            Person person2 = new Person() { Id = 2, name = "Jane Smith", age = 25, email = "jane.smith@example.com" };

            context.Persons.Add(person1);
            context.Persons.Add(person2);
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAll_Returns_All_Persons()
        {
            // Act
            var persons = await repository.GetAll();

            // Assert
            Assert.Equal(2, persons.Count);
        }

        [Fact]
        public async Task getPersonById_Returns_Correct_Person()
        {
            // Act
            var person = await repository.GetById(1);
            // Assert
            Assert.NotNull(person);
            Assert.Equal(1, person.Id);
        }

    }
}
