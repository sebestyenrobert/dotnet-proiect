using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab1.Data;
using Lab1.Models;
using Lab1.ViewModels;
using AutoMapper;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/{id}/comments
        [HttpGet]
        [Route("{id}/comments")]
        public ActionResult<IEnumerable<MovieWithCommentsViewModel>> GetCommentsForMovies (int id)
        {
            var query = _context.Movies
                .Where(m => m.ID == id)
                .Include(m => m.Comments)
                .Select(m => _mapper.Map<MovieWithCommentsViewModel>(m));

            return query.ToList();
        }

        // POST: api/{id}/comments
        [HttpPost]
        [Route("{id}/comments")]
        public IActionResult PostCommentForMovie (int id, Comment comment)
        {
            var movie = _context.Movies
                .Where(m => m.ID == id)
                .Include(m => m.Comments)
                .FirstOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            movie.Comments.Add(comment);
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }



        // GET: api/filter{rating}
        [HttpGet]
        [Route("filter/{rating}")]
        public ActionResult<IEnumerable<Movie>> FilterMovies(int rating)
        {
            return _context.Movies.Where(m => m.Rating >= rating).ToList();
        }

        [HttpGet]
        [Route("createdFilter")]
        public async Task<ActionResult<IEnumerable<Movie>>> FilterByCreatedDate (DateTime? fromDate, DateTime? toDate)
        {
            var filteredMovies = await _context.Movies
                .Where(m => m.CreatedTimestamp >= fromDate && m.CreatedTimestamp <= toDate)
                .OrderByDescending(m => m.Release)
                .Select(m => m)
                .ToListAsync();

            return Ok(filteredMovies);
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieViewModel>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            var movieViewModel = new MovieViewModel
            {
                Director = movie.Director,
                ID = movie.ID,
                Rating = movie.Rating,
                Name = movie.Name

            };

            if (movie == null)
            {
                return NotFound();
            }

            return movieViewModel;
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.ID)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.ID }, movie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }
    }
}
