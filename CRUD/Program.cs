
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductStore>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}"
);
app.Run();
//
// using M02.MVCCRUD.Store;

// var builder = WebApplication.CreateBuilder(args);  

// builder.Services.AddControllersWithViews();

// builder.Services.AddSingleton<ProductStore>();
 
// var app = builder.Build();  

// // products/index   .... list all products
// // products/index/id   .... list specific product
// // products/create

// app.UseRouting();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Products}/{action=index}/{id?}"
// );

// app.Run();
