using Treinando.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
   ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Add services to the container.  
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=ItemEstoques}/{action=Index}/{id?}");

app.Run();
