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
    public class CurrentShowController : ControllerBase
    {
        private readonly IGenericRepositories<CurrentShow> currentShowRepository;
        private readonly IGenericRepositories<Movie> movieRepository;
        private readonly IGenericRepositories<Hall> hallRepository;

        public CurrentShowController(
            IGenericRepositories<CurrentShow> currentShowRepository,
            IGenericRepositories<Movie> movieRepository,
            IGenericRepositories<Hall> hallRepository)
        {
            this.currentShowRepository = currentShowRepository;
            this.movieRepository = movieRepository;
            this.hallRepository = hallRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CurrentShow>>> GetAllCurrentShows()
        {
            List<CurrentShow> currentShows = await currentShowRepository.GetAll();
            return Ok(currentShows);
        }

        [HttpGet("{currentShowId}")]
        public async Task<ActionResult<CurrentShow>> GetCurrentShowById(int currentShowId)
        {
            CurrentShow? currentShow = await currentShowRepository.GetById(currentShowId);

            if (currentShow == null)
            {
                return NotFound();
            }

            return Ok(currentShow);
        }

        [HttpPost]
        public async Task<ActionResult<CurrentShow>> CreateCurrentShow(CurrentShow currentShow)
        {
            CurrentShow createdCurrentShow = await currentShowRepository.Create(currentShow);

            return CreatedAtAction(nameof(GetCurrentShowById), new { currentShowId = createdCurrentShow.currentShowId }, createdCurrentShow);
        }

        [HttpPut("{currentShowId}")]
        public async Task<IActionResult> UpdateCurrentShow(int currentShowId, CurrentShow currentShow)
        {
            if (currentShowId != currentShow.currentShowId)
            {
                return BadRequest();
            }

            CurrentShow? CurrentShowExists = await currentShowRepository.GetById(currentShowId);

            if (CurrentShowExists == null)
            {
                return NotFound();
            }

            CurrentShowExists.movieId = currentShow.movieId;
            CurrentShowExists.hallId = currentShow.hallId;
            CurrentShowExists.showDate = currentShow.showDate;

            await currentShowRepository.Update(CurrentShowExists);
            return NoContent();
        }

        [HttpDelete("{currentShowId}")]
        public async Task<IActionResult> DeleteCurrentShow(int currentShowId)
        {
            bool deleted = await currentShowRepository.Delete(currentShowId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
