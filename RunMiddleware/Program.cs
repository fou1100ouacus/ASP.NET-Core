using System.Net;



// ← Middleware setup goes here 

// Case #1
// app.Use(async (context, next) => {   
//     context.Response.ContentLength = 10;
//     context.Response.Headers.Append("X-Hdr1", "val1"); // Accepted, Response not started
//     context.Response.StatusCode = StatusCodes.Status207MultiStatus;  // Accepted, Response not started
//     await context.Response.WriteAsync("MW #1 \n"); // response has begun
//     // context.Response.Headers.Append("X-Hdr2", "val2"); // Protocol violation; Response has started.
//     // context.Response.StatusCode = StatusCodes.Status206PartialContent; // Protocol violation; Response has started.
//     await next();
// });

// app.Use(async (context, next) => {    
//     await context.Response.WriteAsync("ab\n"); // response has begun
//     await next();
// });


// Case #2
// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("MW #1 \n"); // response has begun
//     await next();
// });

// app.Use(async (context, next) => {    
//     if(!context.Response.HasStarted)
//     {
//         context.Response.StatusCode = StatusCodes.Status207MultiStatus;
//     }
//     await next();
// });


// app.Run();


//========================================================
//========================================================
//========================================================


// using System.Net;

// var builder = WebApplication.CreateBuilder(args);

// // ← DI Container goes here (Configuring Dependencies)

// var app = builder.Build();

// // ← Middleware setup goes here 

// app.Use(async (context, next) => {
//     await context.Response.WriteAsync("MW #1 Before\n");
//     await next();
//     await context.Response.WriteAsync("MW #1 After\n");
// });

// app.Use(async (context, next) => {
//     await context.Response.WriteAsync("     MW #2 Before\n");
//     await next();
//     await context.Response.WriteAsync("     MW #2 After\n");
// });

// app.Use(async (context, next) => {
//     await context.Response.WriteAsync("             MW #3 Before\n");
//     await next();
//     await context.Response.WriteAsync("             MW #3 After\n");
// });

// app.Run();



//=======================================================
//========================================================
//========================================================



// var builder = WebApplication.CreateBuilder(args);

// // ← DI Container goes here (Configuring Dependencies)

// var app = builder.Build();

// // ← Middleware setup goes here 

// // Built-in the framework
// app.UseExceptionHandler();
// app.UseHsts(); 
// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();
// app.UseCors(); 
// app.UseAuthentication(); 
// app.UseAuthorization(); 

// // Custom Middleware
// app.Use(async (context, next) => { await next(); }); 

// // Endpoints
// app.MapGet("/", () => "Hello world");

// app.Run();



//=========================================================
//========================================================
//========================================================


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// ← Middleware setup goes here  

app.Map("/branch1", GetBranch1);

app.Map("/branch2", GetBranch2);

app.Run(async context =>
{
    await context.Response.WriteAsync("Terminal Middleware");
});

app.Run();


static void GetCommonBranch(IApplicationBuilder app)
{
  app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("MW #1\n");
            await next();
        });
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("MW #2\n");
            await next();
        });
}
static void GetBranch1(IApplicationBuilder app)
{
    GetCommonBranch(app);

    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("MW #3\n");
        await next();
    });
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("MW #4\n");
    });
}

static void GetBranch2(IApplicationBuilder app)
{
    GetCommonBranch(app); 

    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("MW #5\n");
        await next();
    });
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("MW #6\n");
    });
}



//===========================================================
//========================================================
//========================================================

// var builder = WebApplication.CreateBuilder(args);

// // ← DI Container goes here (Configuring Dependencies)

// var app = builder.Build();

// // ← Middleware setup goes here  

// app.MapWhen(context => 
//     context.Request.Path.Equals("/checkout", StringComparison.OrdinalIgnoreCase) &&
//     context.Request.Query["mode"] == "new",
// b => {
//     b.Run(async context => {
//         await context.Response.WriteAsync("Modern checkout processing pipeline");
//     });
// });

// app.Map("/checkout", b => {
//     b.Run(async context => {
//         await context.Response.WriteAsync("Legacy checkout processing pipeline");
//     });
// });

// app.Run();

//========================================================
//========================================================
//========================================================



// var builder = WebApplication.CreateBuilder(args);

// // ← DI Container goes here (Configuring Dependencies)

// var app = builder.Build();

// // ← Middleware setup goes here  

// app.UseWhen(context => context.Request.Path.Equals("/branch1", StringComparison.OrdinalIgnoreCase),
// b => {
//     b.Use(async (context, next) => {
//         await context.Response.WriteAsync("MW Branch 1");
//         await next();
//     });
// });
 
// app.Run(async context => {
// await context.Response.WriteAsync("Termianl middleware Main Pipeline");
// });
// app.Run();











