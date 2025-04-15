using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Helpers;
using SistemaDeReservas.API.Services.Interfaces;
using SistemaDeReservas.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHabitacionService, HabitacionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
