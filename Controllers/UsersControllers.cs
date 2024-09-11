using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zenny_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersControllers : ControllerBase
    {

         private readonly ILogger<UsersControllers> _logger;

        //Database Users
        private readonly UserDbContext _context;

        public UsersControllers(ILogger<UsersControllers> logger, UserDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Metodo get (todos los usuarios)
        [HttpGet(Name = "GetUsuarios")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        //metodo get por id (hacer uno donde busque tambien por una letra(buscador))
        [HttpGet("{id}",Name = "GetUsuarioById")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //buscar por letra en nombre y apellido
        [HttpGet("search/{letter}",Name = "GetUsuarioSearch")]
        public async Task<ActionResult<User>> GetUserL(string letter)
        {
             // Verificar que se haya pasado una letra
            if (string.IsNullOrEmpty(letter) || letter.Length != 1)
            {
                return BadRequest("Debe proporcionar una letra para la búsqueda.");
            }

            var queryLetter = letter.ToLower();

            var users = await _context.Users.ToListAsync();

            //StartsWith: comprueba si una cadena de texto(string) comienza con una secuencia de caracteres específica,Devuelve un valor bool.
            var result = users.Where(u => u.Name.StartsWith(queryLetter, StringComparison.OrdinalIgnoreCase) ||
                            u.LastName.StartsWith(queryLetter, StringComparison.OrdinalIgnoreCase)).ToList();

            if (result.Count == 0)
            {
                return NotFound("No se encontraron coincidencias.");
            }

            return Ok(result);

        }


        //metodo create controller -(recordar validacion para que no muestre el campo id)
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetUsuarioById", new {id = user.Id}, user);
        }

        //metodo put (editar) 
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,User user)
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