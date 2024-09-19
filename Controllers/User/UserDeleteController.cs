using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;
using Zenny_Api.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Zenny_Api.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
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
        Summary = "Delete an user", //resumen(este aparece al lado de la ruta en el swagger)
        Description = "Delete an user by id" //Descirpcion aparece cuando abre el endpoint
        )]
        [SwaggerResponse(200, "User successfully deleted", typeof(User))]
        [SwaggerResponse(204, "User not found.")] //no encontrado
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