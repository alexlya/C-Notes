WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Access config values.
string MyKey = builder.Configuration.GetValue<string>("MyKey");

WebApplication app = builder.Build();

// Middleware pipeline.

// Middleware #1.
if (app.Environment.IsDevelopment())
	app.UseDeveloperExceptionPage();

// Middleware #2.
app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName + " | " + MyKey);

// Middleware #3.
app.Run();
