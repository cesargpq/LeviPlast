using AutoMapper;
using LeviPlast.Aplicacion.Interface;
using LeviPlast.Aplicacion.Main;
using LeviPlast.Transversal.Common;
using LeviPlast.Transversal.Mapper;
using LeviPlast.Infraestructura.Data;
using LeviPlast.Infraestructura.Repository;
using LeviPlast.Infraestructura.Interface;
using LeviPlast.Dominio.Interface;
using LeviPlast.Dominio.Core;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(x=> x.AddProfile(new MappingsProfile()));
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomersApplication, CustomerApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomerRepository>();
// Add services to the container.

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
