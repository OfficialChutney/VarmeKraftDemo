using MudBlazor.Services;
using varmekaftDemo.Infrastructure;
using varmekraftDemo.Application;
using varmekraftDemo.Web.Components;
using ApexCharts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddApexCharts();

var app = builder.Build();

app.MapGet("/reports/download/{id}", (string id) =>
{
    var csv =
        "timestamp,price_eur_mwh\n" +
        $"{DateTimeOffset.UtcNow.AddHours(-2):O},52.10\n" +
        $"{DateTimeOffset.UtcNow.AddHours(-1):O},49.80\n" +
        $"{DateTimeOffset.UtcNow:O},51.25\n";

    var bytes = System.Text.Encoding.UTF8.GetBytes(csv);
    var fileName = $"{id}-{DateTime.UtcNow:yyyyMMdd-HHmm}.csv";

    return Results.File(bytes, "text/csv", fileName);
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
