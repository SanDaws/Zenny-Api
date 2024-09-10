using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;

using System;
using System.Collections.Generic;
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


        //metodo get por id
        [HttpGet("{id}",Name = "GetUsuario")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        //metodo create controller  falta por revisar --------------------
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetUsuario", new {id = user.Id},user);
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


        
    }
}