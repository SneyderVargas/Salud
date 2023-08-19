using AutoMapper;
using MySql.Data.MySqlClient;
using SeguimientoDNT.Api.Helpers;
using SeguimientoDNT.Core.Interfaces.Repositories;
using SeguimientoDNT.Infra;
using SeguimientoDNT.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new DbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(mySQLConfiguration);
builder.Services.AddScoped<IPersonasRepo, PersonasRepo>();

var config = new MapperConfiguration(mC =>
{
    mC.AddProfile(new AutoMapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

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
