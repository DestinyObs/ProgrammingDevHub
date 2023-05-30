using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammingDevHub.Data;
using ProgrammingDevHub.Helpers;
using ProgrammingDevHub.Interfaces;
using ProgrammingDevHub.Models;
using ProgrammingDevHub.Services;

namespace ProgrammingDevHub
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //for the newly created repository or service
            builder.Services.AddScoped<IClubRepository, ClubRepository>();
            builder.Services.AddScoped<IMeetUpRepository, MeetUpRepository>();
            builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //Image Cloudinary Upload
            builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

            //ViewModel thing
            builder.Services.AddScoped<IPhotoService, PhotoService>();

            //linking to the DbContext in Mysql
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyString"));
            });

            //Adding Identity Service
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();


            var app = builder.Build();

            //for the seeding
            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                await Seed.SeedUsersAndRolesAsync(app);
                //Seed.SeedData(app);
            }

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

            //for the dash board arrangement
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}