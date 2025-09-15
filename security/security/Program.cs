using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RequestDecompression;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddAuthentication().AddCookie();
// builder.Services.AddAuthentication(options =>{options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;});
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
// builder.Services.AddAuthentication("Cookies");
builder.Services.AddAuthentication().AddCookie(); // AddJwtBearer, AddOpenId

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Supervisor-With-Driver-License-A", policy =>
    {
        policy.RequireClaim("driver-license-class", "A");
        policy.RequireRole("Supervisor");
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", async (HttpContext httpContext) =>
{
    List<Claim> claims = [
        new ("name", " AYA "),
        new ("email", "ayamohamed@localhost"),
          //  new (ClaimTypes.Role, "Admin"),
        new (ClaimTypes.Role, "Supervisor"),
        new ("driver-license-class", "A"),
        new ("sub", Guid.NewGuid().ToString())
    ];

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

    var principal = new ClaimsPrincipal(identity);

    await httpContext.SignInAsync(
        scheme: CookieAuthenticationDefaults.AuthenticationScheme,
        principal: principal
    );
});

app.MapGet("/user",[Authorize] (HttpContext context ) =>
{var principal= context.User;
    if (principal.Identity is {IsAuthenticated : true})
    {
      var claims = principal.Claims.Select(c => new {c.Type, c.Value});
        return Results.Ok(claims);
    }
    return Results.Unauthorized();
});

app.MapGet("/logout", async (HttpContext httpContext) =>
{
  await httpContext.SignOutAsync();
});

app.MapGet("/account/login",
() =>
"Login Page"


);


app.MapGet("/secure", () =>
{
    return Results.Ok("Secure Page");
}).RequireAuthorization();


app.MapGet("/admin-only", () =>
{
    return Results.Ok("Secure Page adminOnly");
}).RequireAuthorization(a => a.RequireRole("Admin"));


app.MapGet("/supervisor-only", [Authorize(Roles = "Admin,Supervisor")] () =>
{
    return Results.Ok("Secure Page supervisor-only");
});


app.MapPost("/drive/bus", () =>
{
    return Results.Ok("Only Class A driver can drive bus");
}).RequireAuthorization("Supervisor-With-Driver-License-A");



app.Run();
