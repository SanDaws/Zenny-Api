using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;
using Zenny_Api.Services;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;


namespace Zenny_Api.Controllers.v2.Users
{
    [ApiController]
    [Route("api/v2/User")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class AuthController : ControllerBase
    {
        // User service for managing user-related operations
        private readonly UserService _userService;

        // Password hasher for securely hashing passwords
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthController(UserService userService)
        {
            _userService = userService;
            _passwordHasher = new PasswordHasher<User>();
        }

        // POST method for user registration
        [HttpPost("Register")]
        [SwaggerOperation(
            Summary = "Create a new user",
            Description = "Creates a new user using specified data"
        )]
        [SwaggerResponse(200, "User successfully created", typeof(User))]
        [SwaggerResponse(400, "User data is required or invalid.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<ActionResult<User>> Register(User user)
        {
            // Check if the user with the given email already exists
            var existingUser = await _userService.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                return BadRequest("A user with that email already exists");
            }

            // Hash the password before saving
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            var newUser = await _userService.CreateUser(user);

            return Ok(newUser);
        }

        // POST method for user login
        [HttpPost("Login")]
        [SwaggerOperation(
            Summary = "Log in a user",
            Description = "Authenticates a user and grants access to the application"
        )]
        [SwaggerResponse(200, "User successfully found", typeof(User))]
        [SwaggerResponse(400, "User data is required or invalid.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<ActionResult<object>> Login([FromBody] LoginRequest loginRequest)
        {
            string email = loginRequest.Email;
            string password = loginRequest.Password;

            // Validate email and password input
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email or password is incorrect");
            }

            // Retrieve user by email
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return BadRequest("Invalid user");
            }

            // Verify the hashed password stored in the database
            var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (passwordVerification == PasswordVerificationResult.Success)
            {
                // Create JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        // Claim representing the user's name
                        new Claim(ClaimTypes.Name, user.Name),
                    }),
                    Expires = DateTime.UtcNow.AddMonths(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                                SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                // Prepare response data including the JWT token and user details
                var dataUser = new
                {
                    token = jwtToken,
                    id = user.Id,
                    name = user.Name,
                    lastname = user.LastName,
                    email = user.Email,
                    subscription_type = user.SubscriptionTypesId
                };

                return Ok(dataUser);
            }

            return BadRequest("Incorrect password");
        }
    }
}