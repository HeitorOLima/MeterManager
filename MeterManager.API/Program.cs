using MeterManager.API.ApplicationContext;
using MeterManager.API.Interfaces;
using MeterManager.API.Repositories;
using MeterManager.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MeterManagerDbContext>(opt => opt.UseInMemoryDatabase("MeterManagerDB"));
builder.Services.AddScoped<IMeterService, MeterService>();
builder.Services.AddScoped<IMeterRepository, MeterRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("MeterManagerCorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

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
