var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/cookies/perference", (HttpContext context) =>
{
    var theme = context.Request.Cookies["theme"];
    var language = context.Request.Cookies["language"];
    var timezone = context.Request.Cookies["timezone"];

    return Results.Ok(new
    {
        Theme = theme,
        Language = language,
        TimeZone = timezone


});
    
});

app.Run();

