using KARA.NET;
using KARA.NET.Data;
using KARA.NET.Web;
using KARA.NET.Web.Pages;

// builder
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

// appsettings
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true);
builder.Services.Configure<List<DatabaseSettings>>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

// misc
var assemblies = App.AddAssembliesFromExecutionPath("KARA.NET", "Authorization", "PasswordManager");
App.AddLogging(builder.Services, x => x.AddConsole());
App.Use<IUnitOfWork, KARA.NET.Data.EntityFramework.UnitOfWork>();
App.Use<IUnitOfWorkFactory, KARA.NET.Data.EntityFramework.UnitOfWorkFactory>();
App.RegisterServices(builder.Services);
App.SetTranslation<Translation>();

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
    .AddInteractiveServerRenderMode();
app.Run();