using System;
using System.Collections.Generic;
using System.Text;
using Cinema2026.Repo.Models;

namespace Cinema2026.Repo.Interfaces
{
    public interface ISeatRepositories
    {
        public List<Seat> GetSeat();
        public Task<List<Seat>> DeleteSeats(int seatId);
        public Task<List<Seat>> GetAllSeats();
        public Task<Seat> CreateSeat(Seat seat);
        public Task<Seat> UpdateSeat(Seat seat);

    }
}
