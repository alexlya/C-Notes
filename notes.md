# Notes

ASP.NET Core can be hosted on IIS, Apache, Nginx, Docker, self-host in your own process, etc.
For more see https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?view=aspnetcore-6.0.

One unified programming model for MVC and Web API. Both `MVC Controller` class and `ASP.NET Web API Controller` class both inherit from the same `Controller` base class and return `IActionResult`. C Common built in implementations of `IActionResult` are `ViewResult` and `JsonResult`.

Built in dependency injection (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0), modular with Middleware Components (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0).

File or folder references are no longer included in the project file. The file system determines what files and folders belong to project. By default, all files and folders belong to project.
