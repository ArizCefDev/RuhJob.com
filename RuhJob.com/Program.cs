using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RuhJob.com.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Cookie
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie((opt =>
  {
      opt.Cookie.HttpOnly = true;
      opt.Cookie.Name = "AuthCookie";
      opt.Cookie.MaxAge = TimeSpan.FromDays(5);

      opt.Events = new CookieAuthenticationEvents
      {
          OnRedirectToLogin = x =>
          {
              x.HttpContext.Response.StatusCode = 401;
              return Task.CompletedTask;
          }
      };
  }));


var app = builder.Build();

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

//cookie
app.UseSession();
app.UseAuthentication();
///

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
