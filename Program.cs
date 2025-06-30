using Microsoft.EntityFrameworkCore;
using MidiotecaWeb.Data;  // Importa seu DbContext correto

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext para usar SQL Server com a connection string do appsettings.json
builder.Services.AddDbContext<MidiotecaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura o Swagger / OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
