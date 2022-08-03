var builder = WebApplication.CreateBuilder(args);

/*
	Get IConfiguration instance so that we can access confugration in places
	such as appconfig.json, user secrets, etc.
*/
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
var MyKey = configuration.GetValue<string>("MyKey");

var app = builder.Build();

app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName + " | " + MyKey);


app.Run();
