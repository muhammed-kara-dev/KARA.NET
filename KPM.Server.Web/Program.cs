using KARA.NET.AspNet;
using KARA.NET.Data.EntityFramework;
using KPM.Server.Web.Components;

// TODO radzen
var assemblies = KARA.NET.App.AddAssemblies("KARA.NET", "KPM");

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true);
builder.Services.Configure<List<DatabaseSettings>>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddRazorComponents();
ServiceManager.Register(builder.Services);

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddAdditionalAssemblies(assemblies);
app.Run();