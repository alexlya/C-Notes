var builder = WebApplication.CreateBuilder(args);

// Access config values.
var MyKey = builder.Configuration.GetValue<string>("MyKey");

var app = builder.Build();

// Middleware pipeline.

if (app.Environment.IsDevelopment())
	app.UseDeveloperExceptionPage();

app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName + " | " + MyKey);

app.Run();
