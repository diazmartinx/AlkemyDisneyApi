using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlkemyDisneyAPI.Models;
using ContactsApi.Data;
using AlkemyDisneyAPI.DTO;

namespace AlkemyDisneyAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly DataContext _context;

        public FilmsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<IActionResult> GetFilms([FromQuery] GetFilmDTO dto)
        {
            var films = await _context.Films.Select(f => new { f.Title, f.Date, f.GenreID }).ToListAsync();

            if (dto.name != null)
            {           
                films = films.Where(f => f.Title.Contains(dto.name)).ToList();
            }
            if (dto.idGenero != null)
            {
                films = films.Where(f => f.GenreID == dto.idGenero).ToList();
            }
            
            switch (dto.order)
            {
                case "ASC":films = films.OrderBy(f => f.Title).ToList();
                    break;
                case "DSC":films = films.OrderByDescending(f => f.Title).ToList();
                    break;
            }

            return Ok(films);
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);

            if (film == null) return NotFound();

            return film;
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, PutFilmDTO dto)
        {
            var genre = await _context.Genres.FindAsync(dto.GenreId);
            if (genre == null) return BadRequest();

            var film = await _context.Films.FindAsync(id);
            if (film == null) return BadRequest();

            film.Title = dto.Title;
            film.Date = dto.Date;
            film.Rating = dto.Rating;
            film.Genre = genre;

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(PostFilmDTO dto)
        {
            var genre = await _context.Genres.FindAsync(dto.GenreId);
            if (genre == null) return BadRequest();

            var film = new Film();
            film.Title = dto.Title;
            film.Date = dto.Date;
            film.Rating = dto.Rating;
            film.Genre = genre;
            _context.Films.Add(film);
            genre.Films.Add(film);
            _context.SaveChanges();

            return CreatedAtAction("GetFilm", new { id = film.ID }, film);
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.ID == id);
        }
    }
}
