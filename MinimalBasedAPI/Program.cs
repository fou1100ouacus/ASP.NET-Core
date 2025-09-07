using M03.MinimalAPIResponseHandling.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/text", () => "Hello World");

app.MapGet("/json", () => new { Message = "Hello" });
// route here lambdaExpression-IResult
// route or by typeResult
app.MapGet("/api/products-le-ir/{id:guid}", (Guid id, ProductRepository repository) =>
{
    var product = repository.GetProductById(id);

    return product is null
            ? Results.NotFound()
            : Results.Ok(product);
});

app.Run();
