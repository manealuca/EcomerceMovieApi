using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using MoviesEComerce.Controllers;
using MoviesEComerce.Data;
using MoviesEComerce.Data.Cart;
using MoviesEComerce.Data.Services;
using MoviesEComerce.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.
//var a  = configuration.GetSection("WebApiDatabase");
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<MovieComerceContext>();
//builder.Services.AddScoped<IActorService,ActorService>();
builder.Services.AddScoped<IBaseRepository<Actor>, EntityBaseRepository<Actor>>();
builder.Services.AddScoped<IBaseRepository<Producer>, EntityBaseRepository<Producer>>();
builder.Services.AddScoped<IBaseRepository<Cinema>, EntityBaseRepository<Cinema>>();
builder.Services.AddScoped<IBaseRepository<Movie>, EntityBaseRepository<Movie>>();
builder.Services.AddScoped<IOrdersService, OrderService>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
//Authentication - Authorization
builder.Services.AddIdentity<Applicationuser, IdentityRole>().AddEntityFrameworkStores<MovieComerceContext>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

//builder.Services.AddScoped<AppDbInitializer>();
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
        app.UseDeveloperExceptionPage();   
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
