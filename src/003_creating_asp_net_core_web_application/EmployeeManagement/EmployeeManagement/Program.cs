WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Access config values.
string MyKey = builder.Configuration.GetValue<string>("MyKey");

WebApplication app = builder.Build();

// Middleware pipeline.

// Middleware #1.
if (app.Environment.IsDevelopment())
	// Middleware #2.
	app.UseDeveloperExceptionPage();

// Middleware #3.
app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName + " | " + MyKey);

// Middleware #4.
app.Run();
