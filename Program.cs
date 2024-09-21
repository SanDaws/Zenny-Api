using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using DotNetEnv;
using Zenny_Api.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Zenny_Api;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
        {
            //convertir cadena a matriz de bytes
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key")));
            //define clave y algoritmo para firar el token
            var SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature);
            opt.RequireHttpsMetadata = false;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                //opciones de devop
                ValidateAudience = false,
                ValidateIssuer = false,
                //nuestra firma
                IssuerSigningKey = signinKey,
            };
        });

        // Add services to the container.
        Env.Load();
        var UdbHost = Environment.GetEnvironmentVariable("UDB_HOST");
        var UdbPort = Environment.GetEnvironmentVariable("UDB_PORT");
        var UdbDatabaseName = Environment.GetEnvironmentVariable("UDB_NAME");
        var UdbUser = Environment.GetEnvironmentVariable("UDB_USER");
        var UdbPassword = Environment.GetEnvironmentVariable("UDB_PASSWORD");

        //MOVEMETDB
        var MovementDbHost = Environment.GetEnvironmentVariable("MOVEMETDB_HOST");
        var MovementDbPort = Environment.GetEnvironmentVariable("MOVEMETDB_PORT");
        var MovementDbDatabaseName = Environment.GetEnvironmentVariable("MOVEMETDB_DATABASE");
        var MovementDbUser = Environment.GetEnvironmentVariable("MOVEMETDB_USERNAME");
        var MovementDbPassword = Environment.GetEnvironmentVariable("MOVEMETDB_PASSWORD");

        // Movement dabase conection
        var MovementDBonectionDB = $"server={MovementDbHost};port={MovementDbPort};database={MovementDbDatabaseName};uid={MovementDbUser};password={MovementDbPassword}";
        builder.Services.AddDbContext<MovementDbContext>(options =>
            options.UseMySql(MovementDBonectionDB, ServerVersion.Parse("8.0.20-mysql")));

        builder.Services.AddScoped<MovementService>();

        //user database conection
        var UconectionDB = $"server={UdbHost};port={UdbPort};database={UdbDatabaseName};uid={UdbUser};password={UdbPassword}";

        builder.Services.AddDbContext<UserDbContext>(options =>
            options.UseMySql(UconectionDB, ServerVersion.Parse("8.0.20-mysql")));

        builder.Services.AddControllers();

        // swagger       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Farm", Version = "v1" });
                c.EnableAnnotations();
            }
        );
        // Registro del servicio UserService
        builder.Services.AddScoped<UserService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

//otra forma de hacerlo pero con autoriazacion en el swagger
// namespace Zenny_Api;

// public class Program
// {
//     public static void Main(string[] args)
//     {

//         var builder = WebApplication.CreateBuilder(args);

//         builder.Services.AddAuthorization();
//         builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
//         {
//             var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key")));
//             //define clave y algoritmo para firar el token
//             var SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature);
//             //si requiere http para autenticacion,establecer como true para mas seguridad
//             opt.RequireHttpsMetadata = false;
//             opt.TokenValidationParameters = new TokenValidationParameters()
//             {
//                 //opciones de devop
//                 //si quiero que mi api sea estricta en base a que front la consume
//                 ValidateAudience = false,
//                 ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
//                 //nuestra firma
//                 IssuerSigningKey = signinKey,
//             };
//         });

//         // Add services to the container.
//         Env.Load();
//         var UdbHost = Environment.GetEnvironmentVariable("UDB_HOST");
//         var UdbPort = Environment.GetEnvironmentVariable("UDB_PORT");
//         var UdbDatabaseName = Environment.GetEnvironmentVariable("UDB_NAME");
//         var UdbUser = Environment.GetEnvironmentVariable("UDB_USER");
//         var UdbPassword = Environment.GetEnvironmentVariable("UDB_PASSWORD");

//         //MOVEMETDB
//         var MovementDbHost = Environment.GetEnvironmentVariable("MOVEMETDB_HOST");
//         var MovementDbPort = Environment.GetEnvironmentVariable("MOVEMETDB_PORT");
//         var MovementDbDatabaseName = Environment.GetEnvironmentVariable("MOVEMETDB_DATABASE");
//         var MovementDbUser = Environment.GetEnvironmentVariable("MOVEMETDB_USERNAME");
//         var MovementDbPassword = Environment.GetEnvironmentVariable("MOVEMETDB_PASSWORD");

//         // Movement dabase conection
//         var MovementDBonectionDB = $"server={MovementDbHost};port={MovementDbPort};database={MovementDbDatabaseName};uid={MovementDbUser};password={MovementDbPassword}";
//         builder.Services.AddDbContext<MovementDbContext>(options =>
//             options.UseMySql(MovementDBonectionDB, ServerVersion.Parse("8.0.20-mysql")));

//         builder.Services.AddScoped<MovementService>();

//         //user database conection
//         var UconectionDB = $"server={UdbHost};port={UdbPort};database={UdbDatabaseName};uid={UdbUser};password={UdbPassword}";

//         builder.Services.AddDbContext<UserDbContext>(options =>
//             options.UseMySql(UconectionDB, ServerVersion.Parse("8.0.20-mysql")));

//         builder.Services.AddControllers();

//         // swagger       
//         builder.Services.AddEndpointsApiExplorer();
//         builder.Services.AddSwaggerGen(c =>
//             {
//                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Farm", Version = "v1" });
//                 c.EnableAnnotations();

//                 c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme 
//                 {
//                     Type = SecuritySchemeType.Http,
//                     Name = "Authorization",
//                     In = ParameterLocation.Header,
//                     Scheme = "Bearer",
//                     Description = "Bearer token authentication"
//                 });

//                 c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                 {
//                     {
//                         new OpenApiSecurityScheme
//                         {
//                             Reference = new OpenApiReference
//                             {
//                                 Type = ReferenceType.SecurityScheme,
//                                 Id = "Bearer"
//                             }
//                         },
//                         new string[] {}
//                     }
//                 });
//             }
//         );
//         // Registro del servicio UserService
//         builder.Services.AddScoped<UserService>();

//         var app = builder.Build();

//         // Configure the HTTP request pipeline.
//         if (app.Environment.IsDevelopment())
//         {
//             app.UseSwagger();
//             app.UseSwaggerUI();
//         }

//         app.UseHttpsRedirection();

//         app.UseAuthentication(); 
//         app.UseAuthorization();

//         app.MapControllers();

//         app.Run();
//     }
// }

