using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;
using Zenny_Api.Services;

namespace Zenny_Api.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserUpdateController : ControllerBase
    {
        private readonly UserService _Userservice;

        public UserUpdateController(UserService userService)
        {
            _Userservice = userService;
        }

        //Update for id ---------------------------------------------------------------------------------------
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest("Id no encontrado");
            }

            var newUser = await _Userservice.UpdateUser(user);

            if (newUser == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            return Ok();
        }
        
    }
}