using Dapr.Client;
using Dapr.Extensions.Configuration;
using DocBrown.Infra.Abstractions.Repositories;
using DocBrown.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDaprClient();
//builder.Configuration.AddDaprSecretStore("secretstore",
//	   new DaprClientBuilder().Build());


builder.Services.AddScoped<IForecasts, RedisForecasters>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
