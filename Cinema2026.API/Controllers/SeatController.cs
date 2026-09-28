using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.AspNetCore.Mvc;
using Cinema2026.Repo.Repositories;

[Route("api/[controller]")]
[ApiController]
public class SeatController : ControllerBase
{
    private readonly IGenericRepositories<Seat> seatRepository;

    public SeatController(IGenericRepositories<Seat> seatRepository)
    {
        this.seatRepository = seatRepository;
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
        Seat createdSeat = await seatRepository.Create(seat);

        return CreatedAtAction(
            nameof(GetSeatById),
            new { seatId = createdSeat.seatId },
            createdSeat);
    }

    [HttpPut("{seatId}")]
    public async Task<IActionResult> UpdateSeat(int seatId, Seat seat)
    {
        if (seatId != seat.seatId)
        {
            return BadRequest();
        }

        Seat? existingSeat = await seatRepository.GetById(seatId);

        if (existingSeat == null)
        {
            return NotFound();
        }

        await seatRepository.Update(seat);
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