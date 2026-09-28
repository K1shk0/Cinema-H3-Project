using Microsoft.AspNetCore.Mvc;
using Cinema2026.Repo.Data;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Repositories;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IGenericRepositories<Movie> movieRepository;

    public MoviesController(IGenericRepositories<Movie> movieRepository)
    {
        this.movieRepository = movieRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetAllMovies()
    {
        List<Movie> movies = await movieRepository.GetAll();
        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    public async Task<ActionResult<Movie>> GetMovieById(int movieId)
    {
        Movie? movie = await movieRepository.GetById(movieId);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
    {
        Movie createdMovie = await movieRepository.Create(movie);
        return CreatedAtAction(nameof(GetMovieById), new { movieId = createdMovie.movieId }, createdMovie);
    }

    [HttpPut("{movieId}")]
    public async Task<IActionResult> UpdateMovie(int movieId, Movie movie)
    {
        if (movieId != movie.movieId)
        {
            return BadRequest();
        }

        Movie? MovieExists = await movieRepository.GetById(movieId);

        if (MovieExists == null)
        {
            return NotFound();
        }

        MovieExists.name = movie.name;
        MovieExists.rating = movie.rating;
        MovieExists.genre = movie.genre;
        MovieExists.description = movie.description;
        MovieExists.requiredAge = movie.requiredAge;
        MovieExists.duration = movie.duration;
        MovieExists.cover = movie.cover;

        await movieRepository.Update(MovieExists);
        return NoContent();
    }

    [HttpDelete("{movieId}")]
    public async Task<IActionResult> DeleteMovie(int movieId)
    {
        bool deleted = await movieRepository.Delete(movieId);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
