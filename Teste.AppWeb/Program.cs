using Teste.AppWeb.Core.Services;
using Teste.AppWeb.Core.Services.Request;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorPages();

builder.Services
    .AddScoped<IRequestService, RequestService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();