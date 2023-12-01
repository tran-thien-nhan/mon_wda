using homework3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(60));

//set timeout trong 5p
//opt => opt.IdleTimeout = TimeSpan.FromMinutes(5)

//đăng ký connection
builder.Services.AddDbContext<StockContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Stock");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Stock}/{action=Login}/{id?}");

app.Run();
