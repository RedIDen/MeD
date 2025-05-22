using AuthorizationService.Application.Handlers;
using AuthorizationService.Application.Services;
using AuthorizationService.Domain.Model;
using AuthorizationService.Domain.Repositories;
using AuthorizationService.Persistence.Context;
using AuthorizationService.Persistence.Entities;
using AuthorizationService.Persistence.Mappers;
using AuthorizationService.Persistence.Repositories;
using Core.Logging;
using Core.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ILogger = Core.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthorizationDbContext>();
builder.Services.AddScoped<ILogger, ConsoleLogger>();
builder.Services.AddScoped<IMapper<AuthorizationUser, AuthorizationUserEntity>, AuthorizationUserMapper>();
builder.Services.AddScoped<IAuthorizationUserRepository, AuthorizationUserRepository>();
builder.Services.AddScoped<RegisterUserHandler>();
builder.Services.AddScoped<LoginUserHandler>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); 

app.Run();
