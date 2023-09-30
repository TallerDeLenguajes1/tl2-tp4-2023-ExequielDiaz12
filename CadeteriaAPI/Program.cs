using CadeteriaAPI.Repositories;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IDbConnection>((sp) => new SQLiteConnection(connectionString));
builder.Services.AddScoped<IClienteRepository,ClienteRepository>();
builder.Services.AddScoped<ICadeteRepository,CadeteRepository>();
builder.Services.AddScoped<IPedidoRepository,PedidoRepository>();

builder.Services.AddControllers();
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
