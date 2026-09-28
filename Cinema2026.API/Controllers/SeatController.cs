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
    public class SeatController : ControllerBase
    {
        private readonly IGenericRepositories<Seat> seatRepository;
        private readonly IGenericRepositories<Hall> hallRepository;

        public SeatController(IGenericRepositories<Seat> seatRepository, IGenericRepositories<Hall> hallRepository)
        {
            this.seatRepository = seatRepository;
            this.hallRepository = hallRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Seat>>> GetAllSeats()
        {
            List<Seat> seats = await seatRepository.GetAll();
            return Ok(seats);
        }

        [HttpGet("{seatId}")]
        public async Task<ActionResult<Seat>> GetSeatById(int seatId)
        {
            Seat? seat = await seatRepository.GetById(seatId);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        [HttpPost]
        public async Task<ActionResult<Seat>> CreateSeat(Seat seat)
        {
            Hall? hall = await hallRepository.GetById(seat.hallId);

            if (hall == null)
            {
                return BadRequest("The hall does not exist.");
            }

            Seat createdSeat = await seatRepository.Create(seat);

            return CreatedAtAction(nameof(GetSeatById), new { seatId = createdSeat.seatId }, createdSeat);
        }

        [HttpPut("{seatId}")]
        public async Task<IActionResult> UpdateSeat(int seatId, Seat seat)
        {
            if (seatId != seat.seatId)
            {
                return BadRequest();
            }

            Seat? seatExists = await seatRepository.GetById(seatId);

            if (seatExists == null)
            {
                return NotFound();
            }

            Hall? hall = await hallRepository.GetById(seat.hallId);

            if (hall == null)
            {
                return BadRequest("The hall does not exist.");
            }

            seatExists.hallId = seat.hallId;
            seatExists.row = seat.row;
            seatExists.column = seat.column;
            seatExists.isAvailable = seat.isAvailable;

            await seatRepository.Update(seatExists);

            return NoContent();
        }

        [HttpDelete("{seatId}")]
        public async Task<IActionResult> DeleteSeat(int seatId)
        {
            bool deleted = await seatRepository.Delete(seatId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}