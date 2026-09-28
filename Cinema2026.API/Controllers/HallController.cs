using Microsoft.AspNetCore.Mvc;
using Cinema2026.Repo.Data;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IGenericRepositories<Hall> hallRepository;

        public HallController(IGenericRepositories<Hall> hallRepository)
        {
            this.hallRepository = hallRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hall>>> GetAllHalls()
        {
            List<Hall> halls = await hallRepository.GetAll();
            return Ok(halls);
        }

        [HttpGet("{hallId}")]
        public async Task<ActionResult<Hall>> GetHallById(int hallId)
        {
            Hall? hall = await hallRepository.GetById(hallId);

            if (hall == null)
            {
                return NotFound();
            }

            return Ok(hall);
        }

        [HttpPost]
        public async Task<ActionResult<Hall>> CreateHall(Hall hall)
        {
            Hall createdHall = await hallRepository.Create(hall);

            return CreatedAtAction(nameof(GetHallById), new { hallId = createdHall.hallId }, createdHall);
        }

        [HttpPut("{hallId}")]
        public async Task<IActionResult> UpdateHall(int hallId, Hall hall)
        {
            if (hallId != hall.hallId)
            {
                return BadRequest();
            }

            Hall? HallExists = await hallRepository.GetById(hallId);

            if (HallExists == null)
            {
                return NotFound();
            }

            HallExists.name = hall.name;
            HallExists.capacity = hall.capacity;

            await hallRepository.Update(HallExists);
            return NoContent();
        }

        [HttpDelete("{hallId}")]
        public async Task<IActionResult> DeleteHall(int hallId)
        {
            bool deleted = await hallRepository.Delete(hallId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
