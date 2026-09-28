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
    public class BookingController : ControllerBase
    {
        private readonly IGenericRepositories<Booking> bookingRepository;
        private readonly IGenericRepositories<Person> personRepository;
        private readonly IGenericRepositories<CurrentShow> currentShowRepository;
        private readonly IGenericRepositories<Seat> seatRepository;

        public BookingController(IGenericRepositories<Booking> bookingRepository, IGenericRepositories<Person> personRepository, IGenericRepositories<CurrentShow> currentShowRepository, IGenericRepositories<Seat> seatRepository)
        {
            this.bookingRepository = bookingRepository;
            this.personRepository = personRepository;
            this.currentShowRepository = currentShowRepository;
            this.seatRepository = seatRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetAllBookings()
        {
            List<Booking> bookings = await bookingRepository.GetAll();
            return Ok(bookings);
        }

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<Booking>> GetBookingById(int bookingId)
        {
            Booking? booking = await bookingRepository.GetById(bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {
            Person? person = await personRepository.GetById(booking.personId);

            CurrentShow? currentShow = await currentShowRepository.GetById(booking.currentShowId);

            Seat? seat = await seatRepository.GetById(booking.seatId);

            if (person == null || currentShow == null || seat == null)
            {
                return BadRequest("The person, current show, or seat doesnt exist.");
            }
            
            if (seat.hallId != currentShow.hallId)
            {
                return BadRequest(
                    "The selected seat does not belong to the CurrentShow hall.");
            }

            Booking createdBooking = await bookingRepository.Create(booking);

            return CreatedAtAction(nameof(GetBookingById), new { bookingId = createdBooking.bookingId }, createdBooking);
        }

        [HttpPut("{bookingId}")]
        public async Task<IActionResult> UpdateBooking(int bookingId, Booking booking)
        {
            if (bookingId != booking.bookingId)
            {
                return BadRequest();
            }

            Booking? bookingExists = await bookingRepository.GetById(bookingId);

            if (bookingExists == null)
            {
                return NotFound();
            }

            Person? person = await personRepository.GetById(booking.personId);
            CurrentShow? currentShow = await currentShowRepository.GetById(booking.currentShowId);
            Seat? seat = await seatRepository.GetById(booking.seatId);

            if (person == null || currentShow == null || seat == null)
            {
                return BadRequest("The person, current show, or seat doesnt exist.");
            }
            if (seat.hallId != currentShow.hallId)
            {
                return BadRequest(
                    "The selected seat does not belong to the CurrentShow hall.");
            }

            bookingExists.personId = booking.personId;
            bookingExists.currentShowId = booking.currentShowId;
            bookingExists.seatId = booking.seatId;
            bookingExists.bookingDate = booking.bookingDate;

            await bookingRepository.Update(bookingExists);

            return NoContent();
        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            bool deleted = await bookingRepository.Delete(bookingId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
