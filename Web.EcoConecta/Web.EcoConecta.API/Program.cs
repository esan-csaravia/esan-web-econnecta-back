using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.Services;
using Web.EcoConecta.CORE.Infraestructure.Data;
using Web.EcoConecta.CORE.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _configuration = builder.Configuration;
var _connectionString = _configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EcoConectaDbContext>(options =>
{
    options.UseSqlServer(_connectionString);
});

builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddTransient<IUsuariosService, UsuariosService>();
builder.Services.AddTransient<ITransaccionesRepository, TransaccionesRepository>();
builder.Services.AddTransient<ITransaccionesService, TransaccionesService>();
builder.Services.AddTransient<ICalificacionesRepository, CalificacionesRepository>();
builder.Services.AddTransient<ICalificacionesService, CalificacionesService>();
builder.Services.AddTransient<IPublicacionesRepository, PublicacionesRepository>();
builder.Services.AddTransient<IPublicacionesService, PublicacionesService>();
builder.Services.AddTransient<IComentariosRepository, ComentariosRepository>();
builder.Services.AddTransient<IComentariosService, ComentariosService>();
builder.Services.AddTransient<ICampanasRepository, CampanasRepository>();
builder.Services.AddTransient<ICampanasService, CampanasService>();
builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<INotificacionesRepository, NotificacionesRepository>();
builder.Services.AddScoped<INotificacionesService, NotificacionesService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseStaticFiles();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
