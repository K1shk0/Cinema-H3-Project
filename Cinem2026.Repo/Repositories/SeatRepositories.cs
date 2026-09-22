using System;
using System.Collections.Generic;
using System.Text;
using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;

namespace Cinema2026.Repo.Repositories
{
    public class SeatRepositories : ISeatRepositories
    {

        private readonly DatabaseContext context;
        public SeatRepositories(DatabaseContext d)
        {
            context = d;
        }
        public Task<Seat> CreateSeat(Seat seat)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seat>> DeleteSeats(int seatId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seat>> GetAllSeats()
        {
            throw new NotImplementedException();
        }

        public List<Seat> GetSeat()
        {
            throw new NotImplementedException();
        }

        public Task<Seat> UpdateSeat(Seat seat)
        {
            throw new NotImplementedException();
        }
    }
}
