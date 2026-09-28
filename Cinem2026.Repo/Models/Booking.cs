using System;


namespace Cinema2026.Repo.Models
{
    public class Booking
    {
        public int bookingId { get; set; } // variable / property
        public int personId { get; set; }
        public int currentShowId { get; set; }
        public int seatId { get; set; }
        public DateTime bookingDate { get; set; }
    }
}
