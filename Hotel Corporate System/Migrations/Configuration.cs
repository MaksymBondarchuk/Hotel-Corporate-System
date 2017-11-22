using System;
using System.Data.Entity.Migrations;
using Hotel_Corporate_System.Models;

namespace Hotel_Corporate_System.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HotelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Clients.AddOrUpdate(c => c.Name,
                new Models.Client { Name = "Joe Biden", Birth = new DateTime(1942, 11, 20), IsVip = false },
                new Models.Client { Name = "Barack Obama", Birth = new DateTime(1961, 08, 04), IsVip = false },
                new Models.Client { Name = "Donald Trump", Birth = new DateTime(1946, 06, 14), IsVip = true },
                new Models.Client { Name = "Hillary Clinton", Birth = new DateTime(1947, 10, 26), IsVip = false },
                new Models.Client { Name = "Bernie Sanders", Birth = new DateTime(1941, 09, 08), IsVip = false }
                );
            context.SaveChanges();
        }
    }
}
