using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericRepositories<Person> personRepository;

        public PersonController(IGenericRepositories<Person> personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            List<Person> persons = await personRepository.GetAll();
            return Ok(persons);
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<Person>> GetPersonById(int personId)
        {
            Person? person = await personRepository.GetById(personId);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            Person createdPerson = await personRepository.Create(person);
            return CreatedAtAction(nameof(GetPersonById), new { personId = createdPerson.personId }, createdPerson);
        }

        [HttpPut("{personId}")]
        public async Task<IActionResult>UpdatePerson(int personId, Person person)
        {
            if (personId != person.Id)
            {
                return BadRequest();
            }

            Person? PersonExists = await personRepository.GetById(personId);
            if (PersonExists == null)
            {
                return NotFound();
            }

            await personRepository.Update(person);

            return NoContent();
        }

        [HttpDelete("{personId}")]
        public async Task<IActionResult> DeletePerson(int personId)
        {
            bool deleted = await personRepository.Delete(personId);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
