using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KARA.NET.Blazor;
public static class AppBlazor
{
    public static IComponentRenderMode RenderMode { get; set; } = new InteractiveServerRenderMode(false);
    private static string ErrorHandlingPath { get; set; }

    public static WebApplicationBuilder Build(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services
            .AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true);
        builder.Services.Configure<List<DatabaseSettings>>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
        App.AddLogging(builder.Services, x => x.AddConsole());
        App.RegisterServices(builder.Services);
        return builder;
    }

    public static WebApplicationBuilder LoadAdditionalAssemblies(this WebApplicationBuilder builder, params string[] fileNamesStartsWith)
    {
        App.AddAssembliesFromExecutionPath(fileNamesStartsWith);
        return builder;
    }

    public static WebApplicationBuilder Use<TService, TImplementation>(this WebApplicationBuilder builder)
    {
        App.Use<TService, TImplementation>();
        return builder;
    }

    public static WebApplicationBuilder SetTranslation<T>(this WebApplicationBuilder builder)
    {
        App.SetTranslation<T>();
        return builder;
    }

    public static WebApplicationBuilder SetErrorHandlingPath(this WebApplicationBuilder builder, string path)
    {
        AppBlazor.ErrorHandlingPath = path;
        return builder;
    }

    public static void Run<T>(this WebApplicationBuilder builder)
    {
        var app = builder.Build();
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler(errorHandlingPath: AppBlazor.ErrorHandlingPath, createScopeForErrors: true);
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapRazorComponents<T>()
            .AddInteractiveServerRenderMode();
        app.Run();
    }
}