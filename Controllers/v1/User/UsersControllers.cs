using Microsoft.AspNetCore.Mvc;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Zenny_Api.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class UsersControllers : ControllerBase
    {
        private readonly ILogger<UsersControllers> _logger;
        //service
        private readonly UserService _Userservice;

        public UsersControllers(ILogger<UsersControllers> logger, UserService Userservice)
        {
            _logger = logger;
            _Userservice = Userservice;
        }

        //get for id ----------------------
        [HttpGet("{id}", Name = "GetUsuarioById")]
        [SwaggerOperation(
        Summary = "Get the user with an specific id",
        Description = "Returns the user with an specific id"
        )]
        [SwaggerResponse(200, "Returns a user with the id that an specific.", typeof(Movement))]
        [SwaggerResponse(400, "There are no registered user.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(int id)
        {
            var user = await _Userservice.GetUserById(id);

            if (user == null)
            {
               return NotFound("Usuario no encontrado");
            }

            return Ok(user);
        }

    }
}