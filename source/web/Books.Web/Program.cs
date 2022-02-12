using Books.DataServices;
using Books.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IBookDataService, BookDataService>(client =>
    {
#pragma warning disable CS8604 // Possible null reference argument.
        client.BaseAddress = new Uri(builder?.Configuration["WebApis:Books"]);
#pragma warning restore CS8604 // Possible null reference argument.
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", builder.Configuration["WebApis:ApimSubscriptionKey"]);
    }
);

await builder.Build().RunAsync();
