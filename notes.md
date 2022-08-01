# Notes

ASP.NET Core can be hosted on IIS, Apache, Nginx, Docker, self-host in your own process, etc.
For more see https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?view=aspnetcore-6.0.

One unified programming model for MVC and Web API. Both `MVC Controller` class and `ASP.NET Web API Controller` class both inherit from the same `Controller` base class and return `IActionResult`. C Common built in implementations of `IActionResult` are `ViewResult` and `JsonResult`.

Built in dependency injection (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0), modular with Middleware Components (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0).

File or folder references are no longer included in the project file. The file system determines what files and folders belong to project. By default, all files and folders belong to project.

Can enable implicit usings in `csproj` file:

```xml
<PropertyGroup>
    <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>
```

---

## `InProcess` vs `OutOfProcess` hosting.

`InProcess` hosts the app inside of the IIS worker process - `w3wp.exe` for IIS or `iisexpress.exe` for IIS Express. 

`OutOfProcess` hosting model forwards web requests to a backend ASP.NET Core app running the Kestrel server.

Default is `OutOfProcess` hosting.

`InProcess` delivers significantly higher throughput than `OutOfProcess`.

With `OutOfProcess` hosting there are 2 servers - Internal and External server. Internal server is Kestrel. External server is IIS, Nginx or Apache.

## Kestrel

Kestrel is cross-platform web server for ASP.NET Core. It is included as an internal component of ASP.NET Core. It can be used by itself as an edge server (internet facing server). Name of process is `dotnet.exe`.

---

ASP.NET Core application initially starts as a Console application.

.NET 6 removed `Startup.cs` file. Put necessary contents inside `Program.cs` file.
