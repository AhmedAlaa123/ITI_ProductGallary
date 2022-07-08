using Microsoft.EntityFrameworkCore;
using ProductGallary.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// register

// connection String
string connectionString = builder.Configuration.GetConnectionString("AhmedAlaa");
builder.Services.AddDbContext<Context>(optionBuilder =>
{
    optionBuilder.UseSqlServer(connectionString);
});

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
