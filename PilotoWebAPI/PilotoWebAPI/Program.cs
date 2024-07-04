using Microsoft.EntityFrameworkCore;
using PilotoWebAPI.Models;
using PilotoWebAPI.Repositories.IRepositories;
using PilotoWebAPI.Repositories;
using PilotoWebAPI.Services.IServices;
using PilotoWebAPI.Services;
using PilotoWebAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositorios y Servicios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPilotoRepository, PilotoRepository>();
builder.Services.AddScoped<IPilotoService, PilotoService>();

builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<IPaisService, PaisService>();


//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//DbContext
builder.Services.AddDbContext<PilotLoginContext>((context) =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("pilotoDb"));
});

var app = builder.Build();

//Cors
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
