using Microsoft.EntityFrameworkCore;
using PruebaNET.BL.Clase;
using PruebaNET.BL.Interfaces;
using PruebaNET.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONFIGURANDO EL ACCESO A LOS DATOS
var conn = builder.Configuration.GetConnectionString("CadenaSQL"); //Creamos variable con la cadena de conexión
builder.Services.AddDbContext<PruebaNetContext>(x => x.UseSqlServer(conn)); //Contruimos el contexto

//CONFIGURANDO LAS INTERFACES PARA QUE EL CONTROLADOR PUEDA VERLAS
builder.Services.AddScoped<IProductos,LogicaProducto>();

builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LogMiddleware>();

app.UseHttpsRedirection();

app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();



app.Run();
