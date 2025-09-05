using BodyBinding.Request;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();



app.MapPost("/product-minimal",  ( Product pro) =>
{
    return Results.Ok(pro);

});

app.Run();
