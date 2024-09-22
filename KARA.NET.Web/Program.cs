using KARA.NET;
using KARA.NET.AspNet;
using KARA.NET.Blazor.Bootstrap;
using KARA.NET.Blazor.Radzen2;
using KARA.NET.Data.EntityFramework;
using KARA.NET.Web;

// TODO authorization
// TODO translator
var assemblies = App.AddAssemblies("KARA.NET", "KPM");

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true);
builder.Services.Configure<List<DatabaseSettings>>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddLogging(x => x.AddConsole());
ServiceManager.Register(builder.Services);
BlazorManager.Register(builder.Services);
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
app.MapRazorComponents<_App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(assemblies);
app.Run();