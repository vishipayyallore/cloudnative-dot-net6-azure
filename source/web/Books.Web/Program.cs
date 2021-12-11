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
        client.BaseAddress = new Uri(builder.Configuration["WebApis:Books"]);
    }
);

await builder.Build().RunAsync();
