using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{ 
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers ()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        //api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers (int id)
        {
            return Ok(await _context.Users.FindAsync(id));
        }
    }
}