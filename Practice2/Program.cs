using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Practice2.Models;
using Practice2.Security;
using Practice2.SolidPrinciple;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();// used to define relationship with controller  with views


//Dependency Injection
builder.Services.AddDbContext<CrudPracticeContext>(o => o.UseSqlServer(builder.Configuration["Conn"]));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddSingleton<DataSecurityProvider>();


var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();


app.UseRouting();
app.MapControllerRoute(
    name:"default",
    pattern:"{Controller=Home}/{Action=Index}/{id?}"
    );
app.Run();
