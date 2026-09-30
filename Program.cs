using Microsoft.EntityFrameworkCore;
using MitraRide.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MitraRideDbContext>(options =>
    options.UseSqlite("Data Source=mitraride.db"));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromHours(4); });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MitraRideDbContext>();
    db.Database.EnsureCreated();
    DbSeeder.Seed(db);
}

if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Home/Error");
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
