using KARA.NET.AspNet;
using KPM.Server.Web.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
ServiceManager.Register(builder.Services, "KARA.NET", "KPM");

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