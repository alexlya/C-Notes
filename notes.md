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

## `launchSettings.json`

This file is only needed in local machine. It is not needed to publish this file to production environments. Settings that you want to be publish need to be stored in `appsettings.json` file. Environmental Variables are configured here.

## `appsettings.json`

In previous versions of ASP.NET configurations were stored in `web.config`. In ASP.NET Core configuration info can come from different sources, such as:

- Files (appsettings.json, appsettings.{Environment}.json)
- User secrets
- Environmental variables
- Command-line arguments

or even our own configuration source.

To access configuration information use `IConfiguration` service. It knows how to read config info from all configuration sources.

To access `IConfiguration` .NET 6 with top-level statements just write this code:

```c#
var builder = WebApplication.CreateBuilder(args);
var MyKey = builder.Configuration.GetValue<string>("MyKey");
```

Settings in `appsettings.{Environment}.json` will override settings in `appsettings.json` file.

Environment variables get stored in `launchSettings.json` under

```json
"profiles": {
    "{name of profile}": {
        "environmentVariables": {
            "MyKey": "this is my key from Environment Variables"
        }
    }
}
```

`IConfugration` reads config info from the following sources in the following order (top to bottom):

1. Files: appsettings.json
2. Files: appsettings.{Environment}.json
3. User secrets
4. Environment variables
5. Command-line arguments

So, config info that is read later overrides config info that was read previously. For example, config settings in user secrets override settings in `appsettings.json`.

## Middleware in ASP.NET Core

In ASP.NET _middleware_ is a piece of software that can handle an HTTP request or response.

For example, we can have a piece of middleware component that can handle authentication, another one to handle errors, another one to server static files (css, js, images, etc.). It is these middleware component that we use to set up a request processing pipeline. It is this pipeline that determines how our request is processed. Request pipeline is configured as part of the application startup by `Configure` method that is present in startup class.

Middleware components are executed in the order that they are added to the pipeline. **Care should be taken to add middleware in the right order, otherwise application may not function as expected**.

[Link to documentation on pipeline order](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0#middleware-order).

![Middleware-pipeline order](./resources/images/middleware-pipeline.svg)

You can add as many or as few middleware components to the pipeline.

Middleware component:
- may simply pass request to the next middleware component in pipeline
- may do _some_ processing and then pass request to the next component in pipeline
- may handle the request and short-circuit the pipeline
- may process outgoing response
- are executed in the order they are added to the pipeline
