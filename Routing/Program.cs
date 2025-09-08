var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// app.MapControllers();
// //1- ==================================================================
// app.MapGet("/products", () =>{
//     return Results.Ok(new [] {
//         "Product #1",
//         "Product #2"
//     });
// });


// app.MapGet("/route-table", (IServiceProvider sp) =>{

//     var endpoints = sp.GetRequiredService<EndpointDataSource>()
//     .Endpoints.Select(ep=>ep.DisplayName);

//     return Results.Ok(endpoints);
// });

//2- ==================================================================

// app.UseRouting();

// #pragma warning restore ASP0014 // Suggest using top level route registrations
// #pragma warning disable ASP0014 // Suggest using top level route registrations
// app.UseEndpoints(ep=> {
//     ep.MapControllers();
//     ep.MapGet("/products", () =>{
//             return Results.Ok(new [] {
//                 "Product #1",
//                 "Product #2"
//             });
//     });
// });
// #pragma warning restore ASP0014 // Suggest using top level route registrations


// //3- ==================================================================


// app.MapGet("/product/{id}", (int id) => $"Product {id}");

// app.MapGet("/date/{year}-{month}-{day}", (int year, int month, int day) 
//     => $"Date is {new DateOnly(year, month, day)}");

// app.MapGet("/{controller=Home}", (string? controller) => controller);

// app.MapGet("/users/{id?}", (int? id) => id is null ? "All users" : $"User {id}");

// app.MapGet("/a{b}c{d}", (string b, string d) => $"b: {b}, d: {d}");

// app.MapGet("/single/{*slug}", (string slug) => $"Slug: {slug}");

// app.MapGet("/double/{**slug}", (string slug) => $"Slug: {slug}");

// app.MapGet("/{id?}/name", (string? id) => $"Id: {id ?? "none"}");


// 4- ==================================================================


// app.MapGet("/int/{id:int}", (int id) 
//     => $"Integer: {id}");

// app.MapGet("/bool/{active:bool}", (bool active) 
//     => $"Boolean: {active}");

// app.MapGet("/datetime/{dob:datetime}", (DateTime dob) 
//     => $"DateTime: {dob}");

// app.MapGet("/decimal/{price:decimal}", (decimal price) 
//     => $"Decimal: {price}");

// app.MapGet("/double/{weight:double}", (double weight) 
//     => $"Double: {weight}");

// app.MapGet("/float/{weight:float}", (float weight) 
//     => $"Float: {weight}");

// app.MapGet("/guid/{id:guid}", (Guid id) 
//     => $"GUID: {id}");

// app.MapGet("/long/{ticks:long}", (long ticks) 
//     => $"Long: {ticks}");

// app.MapGet("/minlength/{username:minlength(4)}", (string username) 
//     => $"MinLength(4): {username}");

// app.MapGet("/maxlength/{filename:maxlength(8)}", (string filename) 
//     => $"MaxLength(8): {filename}");

// app.MapGet("/length/{filename:length(12)}", (string filename) 
//     => $"Exact Length(12): {filename}");

// app.MapGet("/lengthrange/{filename:length(8,16)}", (string filename) 
//     => $"Length(8-16): {filename}");

// app.MapGet("/min/{age:min(18)}", (int age) 
//     => $"Min Age(18): {age}");

// app.MapGet("/max/{age:max(120)}", (int age) 
//     => $"Max Age(120): {age}");

// app.MapGet("/range/{age:range(18,120)}", (int age) 
//     => $"Range(18-120): {age}");

// app.MapGet("/alpha/{name:alpha}", (string name) 
//     => $"Alpha: {name}");

// app.MapGet("/regex/{ssn:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}", (string ssn) 
//     => $"Regex Match (SSN): {ssn}");

// app.MapGet("/required/{name:required}", (string name) 
//     => $"Required: {name}");

// // app.MapGet("/sales/month/{value:validMonth}", (int value) => $"Month: {value}");


// 5- ==================================================================


app.MapGet("/order/{id:int}", (int id, LinkGenerator link, HttpContext context) => {
    // order is retrieved

    var editUrl = link.GetUriByName(
        "EditOrder", 
        new {id}, 
        context.Request.Scheme, 
        context.Request.Host 
    );

    return Results.Ok(new {
        orderId = id,
        status = "PENDING",
        _links = new {
            self = new { href = context.Request.Path  },
            edit = new { href = editUrl, Method = "PUT" }
        }
    });
});


app.MapPut("/order/{id:int}", (int id) => {
    // order is updated

    return Results.NoContent();
}).WithName("EditOrder");

app.Run();







//
