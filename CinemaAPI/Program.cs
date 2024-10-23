using Microsoft.EntityFrameworkCore;
using CinemaAPI.Data;
using CinemaAPI.Util;

var builder = WebApplication.CreateBuilder(args);


Settings.Initialize(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddDbContext<CinemaContext>(options =>
    options.UseSqlServer(Settings.GetConnectionString())); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck<HealthCheckCuston>("Meu Health Check");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();