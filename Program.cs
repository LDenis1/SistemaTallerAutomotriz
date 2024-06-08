using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Dastone.Entities;
using Microsoft.AspNetCore.DataProtection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information() // Establece el nivel m�nimo de log
            .WriteTo.File("C:\\FrostyWorks\\applog.log", rollingInterval: RollingInterval.Day) // Escribe los logs en un archivo
            .CreateLogger();

        builder.Logging.AddSerilog();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Configurar protecci�n de datos
        builder.Services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"C:\keys"))
            .SetApplicationName("MyApplicationName");

        // Configurar la cadena de conexi�n
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<PruebaContexto>(options =>
            options.UseSqlServer(connectionString));

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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Contenido}/{action=Index}/{id?}");

        app.Run();
    }
}