using Microsoft.EntityFrameworkCore;
using ProductManager.ContextFolder;
using ProductManager.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Test_IronWaterStudioConnection"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    SeedData.SeedProducts(app);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.SetLoginData(builder.Configuration);

app.Run();
