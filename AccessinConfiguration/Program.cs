using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// app.MapGet("/get-value-by-ConnectionString", (IConfiguration config) => 
// {

//     return config.GetConnectionString("DefaultConnection");
// }

// );

// app.MapGet("/get-values", (IConfiguration config) => 
// {

//     return config
//     .GetSection(AppSettings.SectionName)
//     .Get<AppSettings>();
// }

// );

// app.MapGet("/bind", (IConfiguration config) =>
// {
//     AppSettings appSettings = new();

//     config.GetSection(AppSettings.SectionName)
//     .Bind(appSettings);

//     return appSettings;

// }

// );


builder.Services.Configure<AppSettings>
(builder.Configuration.GetSection(AppSettings.SectionName));

 var app = builder.Build();

app.MapGet("/options", (IOptions <AppSettings> options) =>
{

    return options.Value;

}

);


app.Run();


public class AppSettings
{
    public const string SectionName = "AppSettings";
    public TimeSpan OpenAt { get; set; }
    public TimeSpan CloseAt { get; set; }
    public TimeSpan DaysOpen { get; set; }
    public bool EnableOnlineBooking { get; set; }
    public int MaxDailyAppointments { get; set; }
}


