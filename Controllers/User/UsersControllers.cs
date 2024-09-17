using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Zenny_Api.Services;


namespace Zenny_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersControllers : ControllerBase
    {
        private readonly ILogger<UsersControllers> _logger;

        //Database Users
        private readonly UserDbContext _context;
        //service
        private readonly UserService _Userservice;

        public UsersControllers(ILogger<UsersControllers> logger, UserDbContext context, UserService Userservice)
        {
            _logger = logger;
            _context = context;
            _Userservice = Userservice;
        }

        //get for id ----------------------
        [HttpGet("{id}", Name = "GetUsuarioById")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(int id)
        {
            var user = await _Userservice.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }
}