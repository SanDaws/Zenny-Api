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

        //Metodos get (todos los usuarios)------------------------------------------------------------------------
        [HttpGet(Name = "GetUsuarios")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _Userservice.GetAllUsers();

            if (users == null)
            {
                return NotFound();
            }
            return Ok(users); //ActionResult devuelve los datos encapsulados y el tipo de respuesta http
        }


        //metodo get por id----------------------
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

        //Metodos put---------------------------------------------------------------------------------------
        //metodo put (editar) 
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

        //Metodo delete -------------------------------------------------------------------------------------------
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