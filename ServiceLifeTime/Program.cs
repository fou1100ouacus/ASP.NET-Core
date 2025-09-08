// var builder = WebApplication.CreateBuilder(args);


// var app = builder.Build();

// builder.Services.AddScoped<ServiveA>();
// builder.Services.AddScoped<ServiveB>();

// builder.Services.AddSingleton<RequestTracker>();


// app.MapGet("/check", (ServiveA a, ServiveB b) =>
// {
   
//     return Results.Ok(new
//     {
//         ServiceA = a.GetTrackerId(),
//         ServiceB = b.GetTrackerId()
//     });
// });


// app.Run();
// public class RequestTracker
// {
//     public string TrackerID = Guid.NewGuid().ToString()[..8];

// }
// public class ServiveA(RequestTracker tracker)
// {
//     public string GetTrackerId() => tracker.TrackerID;
// }public class ServiveB(RequestTracker tracker)
// {
//     public string GetTrackerId() => tracker.TrackerID;
// }
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ServiceA>();
builder.Services.AddScoped<ServiceB>();

builder.Services.AddScoped<RequestTracker>();

var app = builder.Build();

app.MapGet("/check", (ServiceA serviceA, ServiceB serviceB) =>{

    return Results.Ok(
        new {
            A = serviceA.GetInfo(),
            B = serviceB.GetInfo()
        }
    );
});
app.MapGet("/check2", (ServiceA serviceA) => {

    return Results.Ok(serviceA.GetInfo());
});
 
app.Run();


public class RequestTracker
{
    public string TrackerId = Guid.NewGuid().ToString()[..8];
}

public class ServiceA(RequestTracker tracker)
{
    public string GetInfo()
        => $"A ⇨ {tracker.TrackerId}";
}

public class ServiceB(RequestTracker tracker)
{
    public string GetInfo()
        => $"B ⇨ {tracker.TrackerId}";
}