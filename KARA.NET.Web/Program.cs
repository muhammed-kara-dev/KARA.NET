using KARA.NET;
using KARA.NET.Data.EntityFramework;
using KARA.NET.Web;
using KARA.NET.Web.Pages;
using Microsoft.AspNetCore.Components.Authorization;

var assemblies = App.AddAssembliesFromExecutionPath();
Translator.SetResource();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true);
builder.Services.Configure<List<DatabaseSettings>>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddLogging(x => x.AddConsole());
foreach (var serviceManager in ReflectionUtils.CreateInstancesOfInterface<IServiceManager>(App.Assemblies))
{
    serviceManager.Register(builder.Services);
}
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationCore();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/authorization/login";
    x.LogoutPath = "/authorization/logout";
    x.AccessDeniedPath = "/authorization/accessdenied";
});
//builder.Services.AddCors(x =>
//{
//    x.AddPolicy("CorsPolicy", y =>
//    {
//        y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//    });
//});
//builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingServerAuthenticationStateProvider<IUser>>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler($"/{nameof(Error)}", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<_App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(assemblies);
app.Run();