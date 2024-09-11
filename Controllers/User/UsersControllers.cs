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

        //Metodo get (todos los usuarios)
        [HttpGet(Name = "GetUsuarios")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        //metodo get por id
        [HttpGet("{id}", Name = "GetUsuarioById")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
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

            return Ok(false);  // Email o contraseña incorrectos
        }

        //metodo create controller -(recordar validacion para que no muestre el campo id)
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetUsuarioById", new { id = user.Id }, user);
        }

        //metodo put (editar) 
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        //metodo delete por id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userFound = await _context.Users.FindAsync(id);

            if (userFound == null)
            {
                return NotFound("Usuario no encontrado");
            }

            _context.Users.Remove(userFound);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return BadRequest("No se pudo eliminar e usuario");
            }

            return Ok("Usuario eliminado de forma exitosa");
        }



    }
}