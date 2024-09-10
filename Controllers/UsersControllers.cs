using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;

namespace Zenny_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersControllers : ControllerBase
    {

         private readonly ILogger<UsersControllers> _logger;

        //Database Users
        private readonly UserDbContext _context;

        public UsersControllers(ILogger<UsersControllers> logger, UserDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Metodo get
        [HttpGet(Name = "GetProductos")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            //return await _context.users.TolistAsyc();
            return await _context.Users.ToListAsync();
        }


        
    }
}