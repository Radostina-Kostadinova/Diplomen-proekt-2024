using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketsHarbourApp.Core.Contracts;
using TicketsHarbourApp.Core.Services;
using TicketsHarbourApp.Infastructure.Data;
using TicketsHarbourApp.Infrastructure.Data.Domain;
using TicketsHarbourApp.Infrastructure.Data.Infrastructure;

namespace TicketsHarbourApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseLazyLoadingProxies()   
            .UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            { 
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;

            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<ILocationService,LocationService>();
            builder.Services.AddTransient<IConcertService, ConcertService>();
            builder.Services.AddTransient<IEventService, EventService>();
            builder.Services.AddTransient<IConcertService, ConcertService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<IStatisticService, StatisticService>();
            builder.Services.AddTransient<IContactService, ContactService>();

            var app = builder.Build();
            app.PrepareDatabase();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}