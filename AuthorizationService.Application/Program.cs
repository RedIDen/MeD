using AuthorizationService.Application.Handlers;
using AuthorizationService.Domain.Repositories;
using AuthorizationService.Persistence.Context;
using AuthorizationService.Persistence.Repositories;
using Core.Logging;
using ILogger = Core.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILogger, ConsoleLogger>();
builder.Services.AddDbContext<AuthorizationDbContext>();
builder.Services.AddScoped<IAuthorizationUserRepository, AuthorizationUserRepository>();
builder.Services.AddScoped<RegisterUserHandler>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();
