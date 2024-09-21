using KARA.NET.AspNet;
using KPM.Business;
using KPM.Server.Web.Components;

// facade wird nicht registriert
// password.name wird nicht gemapt
// appsettings

KARA.NET.App.AddAssemblies("KARA.NET", "KPM");

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true);
builder.Services.AddRazorComponents();
builder.Services.AddScoped<PasswordFacade>();
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
app.MapRazorComponents<App>();
app.Run();