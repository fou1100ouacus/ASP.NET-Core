// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
// builder.Services.AddTransient<IPaymentProvider>(sp =>
// {
//   var config = sp.GetRequiredService<IConfiguration>();
//   return config["paymentProvider"] == "Stripe"
//     ? new StripePaymentProvider() 
//     : new PayPalPaymentProvider();
  
// });


// app.MapGet("/pay/{amount}", (decimal amount, IPaymentProvider payprovider) =>
// {var response= payprovider.Pay(amount);
//   return Results.Ok(response);

// });

// app.Run();


// public interface IPaymentProvider
// {
//   string Pay(decimal amount);
// }
// public class PayPalPaymentProvider : IPaymentProvider
// {
//   public string Pay(decimal amount)
//   {
//     return $"Paid {amount} using PayPal.";
//   }
// }

// public class StripePaymentProvider : IPaymentProvider
// {
//   public string Pay(decimal amount)
//   {
//     return $"Paid {amount} using Stripe.";
//   }
// }

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IPaymentProvider>(sp =>
{
  var config = sp.GetRequiredService<IConfiguration>();
  return config["PaymentProvider"] == "Stripe" ? new StripePayment() : new PayPalPayment();
});

var app = builder.Build();

app.MapGet("/pay/{amount}", (decimal amount, IPaymentProvider paymentProvider) => {
    var response = paymentProvider.Pay(amount);
    return Results.Ok(response);
});

app.Run();

public interface IPaymentProvider
{
    string Pay(decimal amount);
}

public class StripePayment : IPaymentProvider
{
    public string Pay(decimal amount)
        => $"Payment of ${amount} was processed using Strip!";
}

public class PayPalPayment : IPaymentProvider
{
    public string Pay(decimal amount)
        => $"Payment of ${amount} was processed using PayPal!";
}