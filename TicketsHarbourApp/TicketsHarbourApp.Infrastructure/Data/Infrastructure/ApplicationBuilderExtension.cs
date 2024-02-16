using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Infastructure.Data;
using TicketsHarbourApp.Infrastructure.Data.Domain;

namespace TicketsHarbourApp.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

           var dataLocation = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedLocations(dataLocation);
            var dataConcert = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedConcerts(dataConcert);
         

            return app;
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

        }
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.Address = "admin address";
                user.PhoneNumber = "0888888888";


                var result = await userManager.CreateAsync
                    (user, "Admin123456");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();


                }
            }
        }

      
        private static void SeedLocations(ApplicationDbContext dataLocation)
        {
            if (dataLocation.Locations.Any())
            {
                return;
            }

            dataLocation.Locations.AddRange(new[]
            {
               new Location{Name="Krakra", Town="Pernik",Address="street Nikola Aspasiev-15"},
               new Location{Name="Stadium V. Levski", Town="Sofia",Address="street Nikola Vapcarov-55"},
               new Location{Name="Arena Armeec", Town="Sofia",Address="street Aceen Jordanov- 12"},
               new Location{Name="Arena Arez", Town = "Sofia", Address = "street Nikola Vapcarov-85"},
               new Location{Name="Arena SunnyDay", Town="Varna",Address="street Ivan Vazov-24"},
               new Location{Name="Morksa Sirena", Town="Burgas",Address="street Sofrini Vrachanski- 21"},
               new Location{Name="Stadium The Old Town", Town="Stara Zagora",Address="street Sirma Voevoda-3"},
               new Location{Name="Smart Watch", Town="Ruse",Address="street  Pencho Slaveikov-9"}
        });
            dataLocation.SaveChanges();
        }



        private static void SeedConcerts(ApplicationDbContext dataConcert)
        {
            if (dataConcert.Concerts.Any())
            {
                return;
            }

            dataConcert.Concerts.AddRange(new[]
            {
           new Concert{ConcertName="MolecAlbum", Performers="Molec",Description=" 12 February"   },
           new Concert{ConcertName="Virgo & TRF Album",Performers="Virgo & TRF ",Description="18 March" },
           new Concert{ConcertName="Maneskin Album", Performers="Maneskin",Description="08 April" },
           new Concert{ConcertName="Ari Abdul Album", Performers="Ari Abdul",Description="25 May" },
            });
            dataConcert.SaveChanges();
        }

   

    }
}
