using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static securityJWT.LoginModel;

var builder = WebApplication.CreateBuilder(args);

// === JWT Setup ===
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// === Login Model (no need for a separate class file) ===

// === Login Endpoint - Generates JWT Token ===
app.MapPost("/api/login", (LoginModell model) =>
{
    // Fake authentication (replace with your DB later)
    if (model.Username == "ahmed" && model.Password == "123456")
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, model.Username),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim("Subscription", "Premium")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            app.Configuration["Jwt:Key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: app.Configuration["Jwt:Issuer"],
            audience: app.Configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: creds
        );

        return Results.Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

    return Results.Unauthorized();
});

// === Protected Routes ===
app.MapGet("/api/profile", () => "دي صفحتك الشخصية يا وحش 🔥")
    .RequireAuthorization();

app.MapGet("/api/admin", () => "أهلاً يا أدمن الغالي 👑")
    .RequireAuthorization("AdminOnly");

app.MapGet("/api/premium", () => "الكونتنت الـ Premium بس 💎")
    .RequireAuthorization(policy => policy.RequireClaim("Subscription", "Premium"));

app.Run();