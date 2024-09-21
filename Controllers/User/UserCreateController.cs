using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zenny_Api.Models;
using Zenny_Api.Services;

//
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DotNetEnv;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

//Management of hashing.
using Microsoft.AspNetCore.Identity;

namespace Zenny_Api.Controllers.Users
{
    [ApiController]
    [Route("api/v1/User")]
    public class UserCreateController : ControllerBase
    {
        //service
        private readonly UserService _Userservice;

        //hash
        private readonly PasswordHasher<User> _passwordHasher;

        public UserCreateController(UserService userService)
        {
            _Userservice = userService;
            _passwordHasher = new PasswordHasher<User>();
        }


        //Metodos post ----------------------------------------------------------------------------
        //create -(recordar validacion para que no muestre el campo id)
        [HttpPost("Register")]
        [SwaggerOperation(
        Summary = "Create an user",
        Description = "Create an user using specific data" 
        )]
        [SwaggerResponse(200, "User successfully created", typeof(User))]
        [SwaggerResponse(400, "User data is required or invalid.")] 
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<ActionResult<User>> Post(User user)
        {
            //hashear password
            user.Password = _passwordHasher.HashPassword(user, user.Password);

            var newUser = await _Userservice.CreateUser(user);

            return Ok(newUser);
        }

        //Post method for login
        [HttpPost("Login")]
        [SwaggerOperation(
        Summary = "Login an user",
        Description = "Give a specific user access to the application"
        )]
        [SwaggerResponse(200, "User successfully found", typeof(User))]
        [SwaggerResponse(400, "User data is required or invalid.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<ActionResult<string>> ValidateUser([FromForm] string email, [FromForm] string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email o contraseña incorrecta");
            }

            var user = await _Userservice.GetUserByEmail(email);

            if (user == null)
            {
                return BadRequest("Usuario incorrecto");
            }
            //Compares password stored in the database with the one entered by the user (VerifyHashedPassword).
            var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (passwordVerification == PasswordVerificationResult.Success)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                //get coded key.
                var biteKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key"));
                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                    //claim , pieces of information
                    new Claim(ClaimTypes.Name , user.Name),

                }),
                    Expires = DateTime.UtcNow.AddMonths(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(biteKey),
                                                                SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDes);
                //retorn the token
                var jwtToken = tokenHandler.WriteToken(token);

                var dataUser = new 
                {
                    token = jwtToken,
                    id = user.Id,
                    name = user.Name,
                    lastname = user.LastName,
                    email = user.Email,
                    subscription_type = user.SubscriptionTypesId
                };
                // Prepara la respuesta que incluirá el token y otros datos
                var response = new
                {
                    token = jwtToken,
                    nombre = "axa" // Ajusta el valor según sea necesario
                };
                return Ok(dataUser);
                //return Ok(jwtToken);

            }
            
            return BadRequest("Contraseña incorrecta");
        }
    }
}