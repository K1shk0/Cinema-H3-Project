using System;
using System.Collections.Generic;
using System.Text;
using Cinema2026.Repo.Models;

namespace Cinema2026.Repo.Interfaces
{
    public interface IMovieRepositories
    {
        public Task<List<Movie>> GetAllMovies();
        public Task<List<Movie>> DeleteMovies(int movieId);
        public Task<Movie> CreateMovie(Movie movie);
        public Task<Movie> UpdateMovie(Movie movie);
    }
}
