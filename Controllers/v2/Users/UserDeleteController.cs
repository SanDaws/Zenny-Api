using Microsoft.AspNetCore.Mvc;
using Zenny_Api.Services;
using Swashbuckle.AspNetCore.Annotations;
using Zenny_Api.Models;

namespace Zenny_Api.Controllers.v2.Users
{
    [ApiController]
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class UserDeleteController : ControllerBase
    {
        private readonly UserService _Userservice;

        public UserDeleteController(UserService userservice)
        {
            _Userservice = userservice;
        }

        //Delete -------------------------------------------------------------------------------------------
        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Delete an user",
        Description = "Delete an user by id"
        )]
        [SwaggerResponse(200, "User successfully deleted", typeof(User))]
        [SwaggerResponse(204, "User not found.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<ActionResult> Delete(int id)
        {
            var DeleteUser = await _Userservice.DeleteUser(id);

            if (DeleteUser == null)
            {
                return NoContent();
            }

            return Ok(DeleteUser);
        }


    }
}