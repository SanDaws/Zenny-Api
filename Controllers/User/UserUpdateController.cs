using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Zenny_Api.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Zenny_Api.Controllers.Users
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class UserUpdateController : ControllerBase
    {
        private readonly UserService _Userservice;

        public UserUpdateController(UserService userService)
        {
            _Userservice = userService;
        }

        //Update for id ---------------------------------------------------------------------------------------
        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Update user by id",
        Description = "Update user by id the specified id" 
        )]
        [SwaggerResponse(200, "User successfully updated", typeof(User))]
        [SwaggerResponse(204, "User by id not found.")] 
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<ActionResult> Put(int id, User user)
        {
            if (id != user.Id)
            {
                return NoContent();
            }

            var newUser = await _Userservice.UpdateUser(user);

            if (newUser == null)
            {
                return NoContent();
            }
            return Ok(newUser);
        }
        
    }
}