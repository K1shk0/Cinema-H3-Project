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
        private readonly IGenericRepositories<Movie> movieRepository;
        private readonly IGenericRepositories<Seat> seatRepository;
        public BookingController(IGenericRepositories<Booking> bookingRepository, IGenericRepositories<Person> personRepository, IGenericRepositories<Movie> movieRepository, IGenericRepositories<Seat> seatRepository)
        {
            this.bookingRepository = bookingRepository;
            this.personRepository = personRepository;
            this.movieRepository = movieRepository;
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

            Booking? BookingExists = await bookingRepository.GetById(bookingId);

            if (BookingExists == null)
            {
                return NotFound();
            }

            BookingExists.personId = booking.personId;
            BookingExists.movieId = booking.movieId;
            BookingExists.seatId = booking.seatId;
            BookingExists.bookingDate = booking.bookingDate;

            await bookingRepository.Update(BookingExists);
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
