using System;
using System.Collections.Generic;
using System.Text;
using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema2026.Repo.Repositories
{
    public class MovieRepositories : IMovieRepositories
    {
        private readonly DatabaseContext context;
        public MovieRepositories(DatabaseContext d)
        {
            context = d;
        }
        // create 
        // get

        public async Task<List<Movie>> GetAllMovies()
        {
            return await context.Movies.ToListAsync();
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            context.Movies.Add(movie);
            await context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> DeleteMovie(int movieId)
        {
            var searchMovie = await context.Movies.FirstOrDefaultAsync(obj => obj.movieId == movieId);
            if (searchMovie != null)
            {
                context.Movies.Remove(searchMovie);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<List<Movie>> DeleteMovies(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
