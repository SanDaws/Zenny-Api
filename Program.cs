using Microsoft.EntityFrameworkCore;
using Zenny_Api.Data;
using DotNetEnv;
using Zenny_Api.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Zenny_Api.Config;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Zenny_Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Load environment variables
        Env.Load();

        // CORS configuration
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAny", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        // Database connection configuration
        var UdbConnectionString = $"server={Environment.GetEnvironmentVariable("UDB_HOST")};" +
                                   $"port={Environment.GetEnvironmentVariable("UDB_PORT")};" +
                                   $"database={Environment.GetEnvironmentVariable("UDB_NAME")};" +
                                   $"uid={Environment.GetEnvironmentVariable("UDB_USER")};" +
                                   $"password={Environment.GetEnvironmentVariable("UDB_PASSWORD")}";
        builder.Services.AddDbContext<UserDbContext>(options =>
            options.UseMySql(UdbConnectionString, ServerVersion.Parse("8.0.20-mysql")));

        var MovementDbConnectionString = $"server={Environment.GetEnvironmentVariable("MOVEMETDB_HOST")};" +
                                          $"port={Environment.GetEnvironmentVariable("MOVEMETDB_PORT")};" +
                                          $"database={Environment.GetEnvironmentVariable("MOVEMETDB_DATABASE")};" +
                                          $"uid={Environment.GetEnvironmentVariable("MOVEMETDB_USERNAME")};" +
                                          $"password={Environment.GetEnvironmentVariable("MOVEMETDB_PASSWORD")}";
        builder.Services.AddDbContext<MovementDbContext>(options =>
            options.UseMySql(MovementDbConnectionString, ServerVersion.Parse("8.0.20-mysql")));

        // Register services
        builder.Services.AddScoped<MovementService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddSingleton<Utilities>();

        // Add controllers
        builder.Services.AddControllers();

        // API versioning configuration
        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });

        // Swagger configuration
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zenny API", Version = "v1" });
            c.SwaggerDoc("v2", new OpenApiInfo { Title = "Zenny API", Version = "v2" });

            c.EnableAnnotations();

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        // Authentication configuration
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
        {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key")));
            var SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature);
            opt.RequireHttpsMetadata = false;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                //options de devop
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = signinKey,
            };
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
            });
        }

        app.UseCors("AllowAny");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
