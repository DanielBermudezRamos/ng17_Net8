using BE_dotnet_api.data;
using BE_dotnet_api.data.Repositories;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -- --- ---- Agregando las instrucciones que necesito para levantar el BackEnd 

// -- --- ---- Opcion 01
//var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
//builder.Services.AddSingleton(mySQLConfiguration);

// -- --- ---- Opcion 02
builder.Services.AddSingleton(new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection")));

builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

// -- --- ---- Opcion 03
// builder.Services.AddDbContext<AppDbContext>(option => option.UseMySql("ConnectionStrings:MySqlConnection", null));
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
app.UseCors(option => option.AllowAnyOrigin());

app.Run();
