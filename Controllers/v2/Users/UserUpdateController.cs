using Microsoft.AspNetCore.Mvc;
using Zenny_Api.Models;
using Zenny_Api.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers.v2.Users
{
    [ApiController]
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
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