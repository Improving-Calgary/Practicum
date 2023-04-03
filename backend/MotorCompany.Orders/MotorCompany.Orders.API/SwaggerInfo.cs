using System.Reflection;

namespace MotorCompany.Orders.API;

public class SwaggerInfo
{
    public static SwaggerInfo Create(int apiVersion = 1) => new SwaggerInfo(apiVersion);
    
    public SwaggerInfo(int apiVersion)
    {
        Title = Assembly.GetEntryAssembly()?.GetName().Name ?? "Api";
        Version = $"v{apiVersion}";
        Name = $"{Title} {Version}";
    }
    public string Title { get; }

    public string Version { get; }

    public string Name { get; }
}