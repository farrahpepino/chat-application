using server.Repositories;
using server.Services;
using server.Data;
using server.Models;
using server.Middlewares;
using server.WebSockets;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql; 
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var secret = builder.Configuration["Jwt:Secret"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder =>
        {
            builder.WithOrigins("*") 
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<AppDbContext>(
    options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();


builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddControllers();



// configure jwt authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // set true for issuer validation
        ValidateAudience = false, // set true for audience validation
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!))
    };
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();
// app.UseHttpsRedirection();
app.UseCors("AllowAngularDev"); 
app.UseWebSockets(); 
app.MapControllers();
app.Map("/ws/chat", ChatWebSocketHandler.HandleAsync);


app.Run();

