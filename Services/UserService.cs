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

        //get user by id
        public async Task<User> GetUserById(int id)
        {
            var userById = await _context.Users.FindAsync(id);

            if (userById == null)
            {
                return null;
            }
            userById.LastName = userById.LastName ?? string.Empty;

            return userById;
        }


        //get user by email
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
        

        //create an user
        public async Task<User> CreateUser(User newUser)
        {
            if (string.IsNullOrEmpty(newUser.LastName))
            {
                newUser.LastName = null;
            }
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        //update an user by id
        public async Task<User> UpdateUser(User updateUser)
        {
            var existingUser = await _context.Users.FindAsync(updateUser.Id);

            if (existingUser == null)
            {
                return null;
            }
            //update existing user data
            existingUser.Name = updateUser.Name;
            existingUser.LastName = updateUser.LastName;
            existingUser.Email = updateUser.Email;
            existingUser.Password = updateUser.Password;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }

        //delete an user by id
        public async Task<User> DeleteUser(int id)
        {
            var userFound = await GetUserById(id);

            if (userFound == null)
            {
                return null;
            }

            _context.Users.Remove(userFound);
            await _context.SaveChangesAsync();

            return userFound;
        }

    }
}