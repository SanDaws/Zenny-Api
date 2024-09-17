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


//Management of hashing.
using Microsoft.AspNetCore.Identity;

namespace Zenny_Api.Controllers.Users
{
    [ApiController]
    [Route("api/User")]
    public class UserCreateController : ControllerBase
    {
        //service
        private readonly UserService _Userservice;

        public UserCreateController(UserService userService)
        {
            _Userservice = userService;
        }

        //Metodos post ----------------------------------------------------------------------------

        //create -(recordar validacion para que no muestre el campo id)
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> Post(User user)
        {
            //hashear password 256
            //user.password = _Userservice.GetSHA256(user.password);
            user.Password = Encrypt.GetSHA256(user.Password);  // Llamada directa a Encrypt

            var newUser = await _Userservice.CreateUser(user);

            return new CreatedAtRouteResult("GetUsuarioById", new { id = user.Id }, newUser);
        }

        //Metodo post para el login
        [HttpPost("Login")]
        public async Task<ActionResult<string>> ValidateUser([FromForm] string email, [FromForm] string password) //Pasar datos como paarte e un formulario HTTP
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email o contraseña incorrecta");
            }

            var user = await _Userservice.GetUserByEmail(email);

            if (user == null || user.Password != password)
            {
                return BadRequest("Email o contraseña incorrectos");
            }

            //Si el usuario es valido generar token
            var tokenHandler =  new JwtSecurityTokenHandler();
            //obtener key codificado.
            var biteKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key"));
            //que tiene el cuerpo de el token-----------------
            var tokenDes = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(new Claim[]{
                //claim , piezas de informacion
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.Name),
                new Claim("subscription", user.SubscriptionTypesId.ToString())

            }),

            //cuando expira el token  --puse apartir de hoy en un mes
            Expires = DateTime.UtcNow.AddMonths(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(biteKey),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            //crear y escribir el token JWT.
            var token = tokenHandler.CreateToken(tokenDes);
            //retorna el toke en un texto plano
            var jwtToken =  tokenHandler.WriteToken(token);

            //retorno el token
            return Ok(jwtToken);
        }
        
    }
}