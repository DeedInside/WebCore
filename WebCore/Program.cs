using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebCore.DALL;
using WebCore.DALL.Interfaces;
using WebCore.DALL.Repositories;
using WebCore.Service.Implementations;
using WebCore.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Connect Data Base in DALL 
builder.Services.AddControllersWithViews();
string? Connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Connection));


// Register interfases to project
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IBlogNewsRepository, BlogNewsRepository>();
builder.Services.AddScoped<IBlogNewsService, BlogNewsService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/Home/Index");
                    options.AccessDeniedPath = new PathString("/Home/Index");
                });
builder.Services.AddAuthorization();
var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();    
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
