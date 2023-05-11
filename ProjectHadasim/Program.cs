using BL;
using BL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddDbContext<HmocaronaContext>(options => options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=HMOCarona;Trusted_Connection=True;"));
builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<UserDTO, User>().ReverseMap();
    config.CreateMap<SickDTO, Sick>().ReverseMap();
    config.CreateMap<Vaccination, VaccinationDTO>().ReverseMap();
}, AppDomain.CurrentDomain.GetAssemblies());
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
