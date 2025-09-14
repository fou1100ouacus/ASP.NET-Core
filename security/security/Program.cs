using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.RequestDecompression;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddAuthentication().AddCookie();
// builder.Services.AddAuthentication(options =>{options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;});
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
// builder.Services.AddAuthentication("Cookies");
builder.Services.AddAuthentication().AddCookie(); // AddJwtBearer, AddOpenId



var app = builder.Build();

app.UseAuthentication();

app.MapGet("/login", async (HttpContext httpContext) =>
{
    List<Claim> claims = [
        new ("name", "Issam A."),
        new ("email", "issam@localhost"),
        new ("sub", Guid.NewGuid().ToString())
    ];

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

    var principal = new ClaimsPrincipal(identity);

    await httpContext.SignInAsync(
        scheme: CookieAuthenticationDefaults.AuthenticationScheme,
        principal: principal
    );
});





app.Run();
