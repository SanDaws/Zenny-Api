using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;
using Zenny_Api.Services;

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
        public async Task<ActionResult> Delete(int id)
        {
            var DeleteUser = await _Userservice.DeleteUser(id);

            if (DeleteUser == null)
            {
                return BadRequest("No se pudo eliminar e usuario");
            }

            return Ok("Usuario eliminado de forma exitosa");
        }

        
    }
}