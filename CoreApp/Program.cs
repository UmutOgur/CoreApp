using CoreApp.Models;
using Microsoft.CodeAnalysis.Options;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>
    (options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DeafultConnection")));

builder.Services.AddDbContext<UserContext>
    (options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("UserConnection")));

builder.Services.AddTransient<ICourseRepository, EfCourseRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
var app = builder.Build();

#pragma warning disable CS8321 // Local function is declared but never used
static void Configure(DataContext dataContext)
{
    SeedDatabase.seed(dataContext);
}
#pragma warning restore CS8321 // Local function is declared but never used

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    

}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
