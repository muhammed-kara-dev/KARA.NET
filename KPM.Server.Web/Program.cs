using KARA.NET.AspNet;
using KARA.NET.Data.EntityFramework;
using KARA.NET.Radzen;
using KPM.Server.Web.Components;

// TODO authorization
var assemblies = KARA.NET.App.AddAssemblies("KARA.NET", "KPM");

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true);
builder.Services.Configure<List<DatabaseSettings>>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddLogging(x => x.AddConsole());
ServiceManager.Register(builder.Services);
RadzenManager.Register(builder.Services);

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();