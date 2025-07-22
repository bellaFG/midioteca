using Microsoft.EntityFrameworkCore;
using Midioteca.Data;
using Microsoft.OpenApi.Models;
using Midioteca.Services; // Para registrar IUsuarioService
using AutoMapper;
using Midioteca.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// =============================================
// 🧭 Configurações de Serviços (DI container)
// =============================================

// DbContext
builder.Services.AddDbContext<MidiotecaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers + Model Binding
builder.Services.AddControllers();

builder.Logging.AddConsole();


// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Midioteca API",
        Version = "v1",
        Description = "API para gerenciamento de livros, filmes, resenhas e usuários."
    });
});

// Registro das Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMidiaService, MidiaService>();

// 📌 Aqui você pode registrar mais Services conforme for criando:
// builder.Services.AddScoped<ILivroService, LivroService>();
// builder.Services.AddScoped<IResenhaService, ResenhaService>();

// =============================================
// 🧭 Configuração do Pipeline HTTP
// =============================================

var app = builder.Build();

// Dev + Prod: Swagger
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
