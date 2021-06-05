using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Lab1.Data;
using Lab1.Models;
using Lab1.ViewModels.Rentals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application, Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public RentalsController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> PlaceRentals(NewRentalRequest newRentalRequest)
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            List<Movie> rentedMovies = new List<Movie>();
            newRentalRequest.RentalMovieIds.ForEach(mid =>
            {
                var movieWithId = _context.Movies.Find(mid);

                if (movieWithId != null)
                {
                    rentedMovies.Add(movieWithId);
                }
            });

            if (rentedMovies.Count == 0)
            {
                return BadRequest();
            }

            var rental = new Rental 
            {
                ApplicationUser = user,
                OrderDateTime = newRentalRequest.RentalDateTime.GetValueOrDefault(),
                Movies = rentedMovies
            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = _context.Rentals.Where(r => r.ApplicationUser.Id == user.Id).Include(r => r.Movies).FirstOrDefault();
            var resultViewModel = _mapper.Map<RentalsForUserResponse>(result);
             
            return Ok(resultViewModel);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRental(UpdateRentalForUser updateRentalRequest)
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Rental rental = _context.Rentals.Where(r => r.Id == updateRentalRequest.Id && r.ApplicationUser.Id == user.Id).Include(r => r.Movies).FirstOrDefault();

            if (rental == null)
            {
                return BadRequest("There is no rentals with this ID.");
            }

            updateRentalRequest.MovieIds.ForEach(mid =>
            {
                var movie = _context.Movies.Find(mid);
                if (movie != null && !rental.Movies.Contains(movie))
                {
                    rental.Movies.ToList().Add(movie);
                }
            });

            _context.Entry(rental).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var rental = _context.Rentals.Where(r => r.ApplicationUser.Id == user.Id && r.Id == id).FirstOrDefault();

            if (rental == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
