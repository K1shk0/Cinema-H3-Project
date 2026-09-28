using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2026.Repo.Models
{
    public class CurrentShow
    {
        public int currentShowId { get; set; } // variable / property
        public int movieId { get; set; }
        public int hallId { get; set; }
        public DateTime showDate { get; set; }
    }
}
