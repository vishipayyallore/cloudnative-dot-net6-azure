using Books.DataServices;
using Books.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Environment.) });

builder.Services.AddHttpClient<IBookDataService, BookDataService>(client =>
{
#pragma warning disable CS8604 // Possible null reference argument.
    client.BaseAddress = new Uri(builder?.Configuration["WebApis:Books"]);
#pragma warning restore CS8604 // Possible null reference argument.
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", builder.Configuration["WebApis:ApimSubscriptionKey"]);
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
