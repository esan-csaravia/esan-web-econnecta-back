using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.Services;
using Web.EcoConecta.CORE.Infraestructure.Data;
using Web.EcoConecta.CORE.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EcoConectaDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Services
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
builder.Services.AddScoped<IBloqueosUsuariosRepository, BloqueosUsuariosRepository>();
builder.Services.AddScoped<IBloqueosUsuariosService, BloqueosUsuariosService>();

builder.Services.AddControllers();

// ? ACTIVAR OPENAPI
builder.Services.AddOpenApi();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b =>
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Esto genera openapi.json y openapi UI
    app.MapOpenApi();
}

app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
