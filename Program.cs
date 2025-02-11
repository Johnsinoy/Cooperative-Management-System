using Microsoft.EntityFrameworkCore;
using Cooperative_Financing.Models;
var builder = WebApplication.CreateBuilder(args);

// ✅ Ensure Connection String is Loaded
var connectionString = builder.Configuration.GetConnectionString("CooperativeContext");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string is missing in appsettings.json.");
}

// ✅ Register DbContext with MySQL
builder.Services.AddDbContext<CooperativeContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
