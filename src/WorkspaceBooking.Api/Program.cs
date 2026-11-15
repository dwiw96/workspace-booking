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

var app = builder.Build(); // Build the app from the registered service and config

// Configure the HTTP request pipeline.
// open route for openapi only in development environment
// Expose OpenAPI only in development to avoid publishing the API contract publicly by default.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection(); // Redirect http to https

app.UseAuthorization(); // Authorization middleware, will be useful when we have [Authorize]

app.MapControllers(); // Expose controller route in request pipeline via [Route] and http method

app.Run();
