using Microsoft.EntityFrameworkCore;
using eShopApi.Data;
using eShopApi.Configurations;
using eShopApi.Middlewares;
using eShopApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Service Collections
builder.Services.AddApplicationServices();
// Add Controller
builder.Services.AddControllers();

// Add Logging
builder.Services.AddLogging();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Database services
var connection_string = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection_string));
// builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
// Add FluentValidation Service
builder.Services.AddFluentValidationConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.UseGlobal404RouteHandling();

app.Run();
