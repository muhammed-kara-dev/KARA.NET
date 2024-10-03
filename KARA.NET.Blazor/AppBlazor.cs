using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KARA.NET.Blazor;
public static class AppBlazor
{
    public static IComponentRenderMode RenderMode { get; set; } = new InteractiveServerRenderMode(false);
    private static string ErrorHandlingPath { get; set; }

    public static IHostApplicationBuilder Build(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services
            .AddRazorComponents()
            .AddInteractiveServerComponents();
        return builder;
    }

    public static IHostApplicationBuilder SetErrorHandlingPath(this IHostApplicationBuilder builder, string path)
    {
        AppBlazor.ErrorHandlingPath = path;
        return builder;
    }

    public static void Run<T>(this IHostApplicationBuilder builder)
    {
        if (builder is WebApplicationBuilder webBuilder)
        {
            var app = webBuilder.Build();
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
}