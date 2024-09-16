using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using DotNetEnv;
using Zenny_Api.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Zenny_Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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

        // Add Swagger services and configure it to include XML comments
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My API",
                Version = "v1",
                Description = "API for user management"
            });
            // Get the XML comments file path
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            // Include the XML comments from the generated file
            c.IncludeXmlComments(xmlPath);
        });
        // Registro del servicio UserService
        builder.Services.AddScoped<UserService>();
        

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
