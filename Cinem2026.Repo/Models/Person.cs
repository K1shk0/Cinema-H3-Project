using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2026.Repo.Models
{
    public class Person
    {
        public int Id { get; set; } // variable / property
        public string name { get; set; }
        public int age { get; set; }
    }

    public class Movie
    {
        public int movieId { get; set; } // variable / property
        public string name { get; set; }
        public decimal rating { get; set; }
        public string genre { get; set; }
    }

    public class Seat
    {
        public int seatId { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public bool isAvailable { get; set; }

    }
}
