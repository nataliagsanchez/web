using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.MVC.Data;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conn = builder.Configuration.GetConnectionString("SchoolManagementDbConnection");
builder.Services.AddDbContext<SchoolManagementDbContext>(q => q.UseSqlServer(conn));

builder.Services
        .AddAuth0WebAppAuthentication(options => {
            options.Domain = builder.Configuration["Auth0:Domain"]!;
            options.ClientId = builder.Configuration["Auth0:ClientId"]!;
        });

builder.Services.AddControllersWithViews().AddViewLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

const string CulturaPorDefecto = "es-ES";
var CulturasSoportadas = new[] { 
    new CultureInfo(CulturaPorDefecto),
    new CultureInfo("en-US"),
    new CultureInfo("it-IT")
};

builder.Services.Configure<RequestLocalizationOptions>(options => {
    options.DefaultRequestCulture = new RequestCulture(CulturasSoportadas[0]);
    options.SupportedCultures = CulturasSoportadas;
    options.SupportedUICultures = CulturasSoportadas;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
