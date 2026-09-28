using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2026.Repo.Models
{
    public class Seat
    {
        public int seatId { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public bool isAvailable { get; set; }
    }
}