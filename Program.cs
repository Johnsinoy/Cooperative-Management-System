using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cooperative_Financing.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Ensure Connection String is Loaded
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string is missing in appsettings.json.");
}

// ✅ Register `CooperativeContext` in Dependency Injection
builder.Services.AddDbContext<CooperativeContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// ✅ Register MVC Controllers & Views
builder.Services.AddControllersWithViews();

// ✅ Add session and distributed memory cache
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Enable session middleware
app.UseSession();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ✅ Set Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// ✅ Run Application
app.Run();
