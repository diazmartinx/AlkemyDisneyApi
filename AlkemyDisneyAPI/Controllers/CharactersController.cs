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
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly DataContext _context;

        public CharactersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<IActionResult> GetCharacters([FromQuery] GetCharacterDTO dto)
        {
            //var characters = await _context.Characters.Select(c => new { c.Name, c.Image }).ToListAsync();
            var characters = await _context.Characters.Include(c => c.Films).ToListAsync();

            if (dto.name != null)
            {
                characters = characters.Where(f => f.Name.Contains(dto.name)).ToList();
            }
            if (dto.age != null)
            {
                characters = characters.Where(f => f.Age == dto.age).ToList();
            }
            if (dto.movies != null)
            {
                var film = await _context.Films.FindAsync(dto.movies);
                characters = characters.Where(films => films.Films.Contains(film)).ToList();
            }

            var res = characters.Select(c => new { c.Name, c.Image }).ToList();

            return Ok(res);
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _context.Characters.Where(c => c.ID == id).Include(f => f.Films).FirstOrDefaultAsync();

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, PutCharacterDTO dto)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null) return BadRequest();


            var films = new List<Film>();

            foreach (int idF in dto.FilmsIDs)
            {
                var list = await _context.Films.FindAsync(idF);
                if (list == null)
                {
                    return BadRequest("Film of id " + idF + " not found.");
                }
                else
                {
                    films.Add(list);
                }
            }
            character.Name = dto.Name;
            character.Age = dto.Age;
            character.Image = dto.Image;
            character.Weight = dto.Weight;
            character.History = dto.History;
            character.Films = films;

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Characters
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(PostCharacterDTO dto)
        {
           var films = new List<Film>();

           foreach(int id in dto.FilmsIDs)
            {
                var list = await _context.Films.FindAsync(id);
                if (list == null) 
                { 
                    return BadRequest("Film of id "+id+" not found."); 
                } else
                {
                    films.Add(list);
                }
            }

            var character = new Character();
            character.Name = dto.Name;
            character.Age = dto.Age;
            character.Image = dto.Image;
            character.Weight = dto.Weight;
            character.History = dto.History;
            character.Films = films;

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.ID }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.ID == id);
        }
    }
}
