using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductGallary;
using ProductGallary.Models;
using ProductGallary.Reposatories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// register
builder.Services.AddScoped<IReposatory<Gallary>,GallaryRepository>();
// connection String
string connectionString = builder.Configuration.GetConnectionString("AhmedAlaa");
builder.Services.AddDbContext<Context>(optionBuilder =>
{
    optionBuilder.UseSqlServer(connectionString);
});


// register identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequireDigit = true;
    option.Password.RequiredLength = 10;

}).AddEntityFrameworkStores<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
// add authintacation middel ware
app.UseAuthentication(); // this important for authentication to work
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
