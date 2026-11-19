using Microsoft.EntityFrameworkCore;
using WorkspaceBooking.Api.Data;

/*
 * Read configuration from appsetting.json, env variables, and cli args
 * DI
 * Logging
 * web server
 */
var builder = WebApplication.CreateBuilder(args); // init the builder

// Add services to the container.

builder.Services.AddControllers(); // Dependency injection for controller
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // api document generator using OpenAPI format
builder.Services.AddHealthChecks();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContext<WorkspaceBookingDbContext>(options =>
{
    options.UseNpgsql(connectionString);
    options.UseSnakeCaseNamingConvention(); // Use snake_case for table and column names
});

var app = builder.Build(); // Build the app from the registered service and config

// Configure the HTTP request pipeline.
// open route for openapi only in development environment
// Expose OpenAPI only in development to avoid publishing the API contract publicly by default.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
