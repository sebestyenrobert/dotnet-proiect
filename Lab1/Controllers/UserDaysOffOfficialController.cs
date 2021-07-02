using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lab1.Data;
using Lab1.Models;
using Lab1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDaysOffOfficialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserDaysOffOfficialController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{userId}/daysoffofficial")]
        public async Task<ActionResult<IEnumerable<UserDaysOffOfficial>>> GetDaysOffOfficialForUser(string userId)
        {
            var query = await _context.UsersDaysOffOfficials
                .Where(u => u.User_id == userId)
                .Select(m => _mapper.Map<UserDaysOffOfficialViewModel>(m))
                .ToListAsync();

            return Ok(query);
        }
    }

    
}