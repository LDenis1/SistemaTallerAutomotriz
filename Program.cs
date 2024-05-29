using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

using Dastone.Entities;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //ConnectrionString
        var connection = builder.Configuration.GetConnectionString("SourceConnection");
        builder.Services.AddDbContext<PruebaContexto>(options => options.UseSqlServer(connection));

        // Configure cookie based authentication
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                           .AddCookie(options =>
                           {
                               // Specify where to redirect un-authenticated users
                               options.LoginPath = "/Security/Index";

                               // Specify the name of the auth cookie.
                               // ASP.NET picks a dumb name by default.
                               options.Cookie.Name = "LoginCookieWebsite";
                               options.AccessDeniedPath = "/Security/Unauthorized";
                           });

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

        // Configure authentication.
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCookiePolicy();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Contenido}/{action=Index}/{id?}");


        



        app.Run();
    }
}