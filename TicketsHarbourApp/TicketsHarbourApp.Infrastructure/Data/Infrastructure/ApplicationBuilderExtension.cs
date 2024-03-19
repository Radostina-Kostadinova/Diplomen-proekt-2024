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
               new Location{Name="Plovdiv", Town="Plovdiv",Address="street Zapaden", LocationUrl="https://maps.app.goo.gl/vh8yMYyGA75DEKaS9"},
               new Location{Name="Petko Enev", Town="Stara Zagora",Address="street Hadji Dimitur Asenov" ,LocationUrl="https://maps.app.goo.gl/FVhY5N6EdCvtmFoV8"},
               new Location{Name="National Stadium Vasil Levski", Town="Sofia",Address="street Evlogi and Hristo Georgievi", LocationUrl = "https://maps.app.goo.gl/b76qxV47TFiPjpT28"},
               new Location{Name="Aleksander Shismanov", Town = "Sofia", Address = "street Koloman" , LocationUrl = "https://maps.app.goo.gl/W9hnQ7f7c2sBhnnG6"},
               new Location{Name="Stadion Spartak", Town="Varna",Address="street Varna Center" , LocationUrl = "https://maps.app.goo.gl/tdr54Se9ogkZmk3K7"},
               new Location{Name="Chernomorec", Town="Burgas",Address="street Lovna 26" , LocationUrl = "https://maps.app.goo.gl/GeCNZJhsep3YKaFq7"},
               new Location{Name="Minior", Town="Pernik",Address="street Fiziculturna" , LocationUrl = "https://maps.app.goo.gl/YzZmn8V3mE2PxDUP6"},
               new Location{Name="Dunav", Town="Ruse",Address="street Rodina" , LocationUrl = "https://maps.app.goo.gl/96Pu2pf7N6muyNz38"}
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
           new Concert{ConcertName="MolecAlbum", Performers="Molec",Description=" 12 February", Picture="" },
           new Concert{ConcertName="Virgo & TRF Album",Performers="Virgo & TRF ",Description="18 March" },
           new Concert{ConcertName="Maneskin Album", Performers="Maneskin",Description="08 April" },
           new Concert{ConcertName="Ari Abdul Album", Performers="Ari Abdul",Description="25 May" },
            });
            dataConcert.SaveChanges();
        }
        //SUS ili bez Picture
   

    }
}
