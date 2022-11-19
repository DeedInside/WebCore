using Microsoft.EntityFrameworkCore;
using WebCore.DALL;
using WebCore.DALL.Interfaces;
using WebCore.DALL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Connect Data Base in DALL 
builder.Services.AddControllersWithViews();
string? Connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Connection));


// Register interfases to project
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

//app.MapGet("/", () => "Hello World!");

app.Run();
