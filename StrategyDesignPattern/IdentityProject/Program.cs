using IdentityProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace IdentityProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            Migration(host);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void Migration(IHost host)
        {
            using IServiceScope scope = host.Services.CreateScope();
            AppIdentityDbContext identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
            UserManager<AppUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            identityDbContext.Database.Migrate();
            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new AppUser() { UserName = "kul1", Email = "kul1@gmail.com" }, "Password123456!").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "kul2", Email = "kul2@gmail.com" }, "Password123456!").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "kul3", Email = "kul3@gmail.com" }, "Password123456!").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "kul4", Email = "kul4@gmail.com" }, "Password123456!").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "kul5", Email = "kul5@gmail.com" }, "Password123456!").Wait();
            }
        }
    }
}