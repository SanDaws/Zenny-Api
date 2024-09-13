using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;
using Zenny_Api.Services;


namespace Zenny_Api.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCreateController : ControllerBase
    {
        //service
        private readonly UserService _Userservice;

        public UserCreateController(UserService userService)
        {
            _Userservice = userService;
        }

        //Metodos post ----------------------------------------------------------------------------

        //metodo create controller -(recordar validacion para que no muestre el campo id)
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> Post(User user)
        {
            var newUser = await _Userservice.CreateUser(user);

            return new CreatedAtRouteResult("GetUsuarioById", new { id = user.Id }, newUser);
        }

        //recibo un json con el email y la contraseña que me envia el frontend
        [HttpPost("validateUser")]
        public async Task<ActionResult<bool>> ValidateUser([FromBody] Dictionary<string, string> credentials) //recibir diccionario desde el cuerpo de la solicitud HTTP.
        {
            if (!credentials.TryGetValue("email", out var email) || !credentials.TryGetValue("password", out var password) || 
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email o contraseña incorrectos");
            }

            var user = await _Userservice.GetUserByEmail(email);

            if (user != null && user.Password == password)
            {
                return Ok(true);
            }

            return Ok(false);
        }
        
    }
}