using KARA.NET;
using KARA.NET.Web;
using KARA.NET.Web.Pages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

// builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// appsettings
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true);
builder.Services.Configure<List<DatabaseSettings>>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

// misc
var assemblies = App.AddAssembliesFromExecutionPath();
App.AddLogging(builder.Services, x => x.AddConsole());
App.RegisterServices(builder.Services);
App.SetTranslation<Translation>();

// authorization
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/authorization/login";
        x.LogoutPath = "/authorization/logout";
        x.AccessDeniedPath = "/authorization/accessdenied";
    });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
foreach (var type in ReflectionUtils.GetCreatableTypesOfInterface<IAuthorizationService>(App.Assemblies))
{
    builder.Services.AddScoped(typeof(IAuthorizationService), type);
}

// app
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