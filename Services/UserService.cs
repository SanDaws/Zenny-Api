using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using Zenny_Api.Models;

namespace Zenny_Api.Services
{
    public class UserService
    {
        //Database Users
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        //Obtener todos los usuarios
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //obtener usuario por id
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        //funcion para obtener el usuario por el email
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        //Crear un usuario
        public async Task<User> CreateUser(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        //editar usuario
        public async Task<User> UpdateUser(User updateUser)
        {
            var existingUser = await _context.Users.FindAsync(updateUser.Id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = updateUser.Name;
            existingUser.LastName = updateUser.LastName;
            existingUser.Email = updateUser.Email;
            existingUser.Password = updateUser.Password;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }

    }
}