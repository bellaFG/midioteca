using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MidiotecaApi.Configurations;
using MidiotecaApi.Data;
using MidiotecaApi.Dtos.Validators;
using MidiotecaApi.Services;
using MidiotecaApi.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// L� appsettings + vari�veis de ambiente
builder.Configuration.AddEnvironmentVariables();

// DbContext (usa "ConnectionStrings:DefaultConnection" do appsettings)
builder.Services.AddDbContext<MidiotecaApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Options pattern para JwtSettings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// ---- JWT (runtime) ----
// OBS: Para gerar migrations voc� j� tem a MidiotecaApiDbContextFactory,
// ent�o o EF usa a factory e ignora este bloco de JWT no design-time.
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

if (string.IsNullOrWhiteSpace(jwtSettings?.SecretKey))
{
    throw new InvalidOperationException(
        "JWT SecretKey is not configured. Set the environment variable: JwtSettings__SecretKey"
    );
}

var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Servi�os pr�prios
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddValidatorsFromAssembly(typeof(UserCreateDtoValidator).Assembly);
builder.Services.AddScoped<IMediaService, MediaService>();


// MVC + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
