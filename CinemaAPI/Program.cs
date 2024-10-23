using Microsoft.EntityFrameworkCore;
using CinemaAPI.Data;
using CinemaAPI.Util;
using CinemaAPI.Services.Interfaces;
using CinemaAPI.Services;
using CinemaAPI.Middleware;
using CinemaAPI.Repositories.Interfaces;
using CinemaAPI.Repositories; 

var builder = WebApplication.CreateBuilder(args);


Settings.Initialize(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddDbContext<CinemaContext>(options =>
    options.UseSqlServer(Settings.GetConnectionString()));

builder.Services.AddScoped<IExibicaoService, ExibicaoService>();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<ISalaService, SalaService>();
builder.Services.AddScoped<ISessaoService, SessaoService>();

builder.Services.AddScoped<IExibicaoRepository, ExibicaoRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<ISalaRepository, SalaRepository>();
builder.Services.AddScoped<ISessaoRepository, SessaoRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddCheck<HealthCheckCuston>("Meu Health Check");

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");
app.UseAuthorization();
app.MapControllers();

app.Run();