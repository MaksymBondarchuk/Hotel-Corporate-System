using System;
using System.Data.Entity.Migrations;
using Hotel_Corporate_System.Models.Database;

namespace Hotel_Corporate_System.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Clients.AddOrUpdate(c => c.Name,
                new Client { Name = "Joe Biden", Birth = new DateTime(1942, 11, 20), IsVip = false },
                new Client { Name = "Barack Obama", Birth = new DateTime(1961, 08, 04), IsVip = false },
                new Client { Name = "Donald Trump", Birth = new DateTime(1946, 06, 14), IsVip = true },
                new Client { Name = "Hillary Clinton", Birth = new DateTime(1947, 10, 26), IsVip = false },
                new Client { Name = "Bernie Sanders", Birth = new DateTime(1941, 09, 08), IsVip = false }
                );

            context.Services.AddOrUpdate(s => s.Name,
                new Service { Name = "Car hire", Amount = 140 },
                new Service { Name = "Bicycle hire", Amount = 14 },
                new Service { Name = "Wake-up call", Amount = 1 },
                new Service { Name = "Conference room", Amount = 50 },
                new Service { Name = "Laundry and dry cleaning", Amount = 3 }
            );

            context.Floors.AddOrUpdate(f => f.Id,
                new Floor { Id = Guid.Parse("00000000-D121-4CF2-A6B2-911E33DD65C5"), Number = 1 },
                new Floor { Id = Guid.Parse("00000001-D121-4CF2-A6B2-911E33DD65C5"), Number = 2 },
                new Floor { Id = Guid.Parse("00000002-D121-4CF2-A6B2-911E33DD65C5"), Number = 3 }
                );

            context.Rooms.AddOrUpdate(f => f.Id,
                new Room { Id = Guid.Parse("10000000-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "101", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000000-D121-4CF2-A6B2-911E33DD65C5") },
                new Room { Id = Guid.Parse("10000001-D121-4CF2-A6B2-911E33DD65C5"), Class = 2, Number = "102", Beds = 2, Cost = 180, FloorId = Guid.Parse("00000000-D121-4CF2-A6B2-911E33DD65C5") },
                new Room { Id = Guid.Parse("10000002-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "103", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000000-D121-4CF2-A6B2-911E33DD65C5") },
                new Room { Id = Guid.Parse("10000003-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "201", Beds = 1, Cost = 350, FloorId = Guid.Parse("00000001-D121-4CF2-A6B2-911E33DD65C5") },
                new Room { Id = Guid.Parse("10000004-D121-4CF2-A6B2-911E33DD65C5"), Class = 3, Number = "202", Beds = 1, Cost = 130, FloorId = Guid.Parse("00000001-D121-4CF2-A6B2-911E33DD65C5") },
                new Room { Id = Guid.Parse("10000005-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "203", Beds = 3, Cost = 250, FloorId = Guid.Parse("00000001-D121-4CF2-A6B2-911E33DD65C5") },
                new Room { Id = Guid.Parse("10000006-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "301", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000002-D121-4CF2-A6B2-911E33DD65C5") },
                new Room { Id = Guid.Parse("10000007-D121-4CF2-A6B2-911E33DD65C5"), Class = 2, Number = "302", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000002-D121-4CF2-A6B2-911E33DD65C5") },
                new Room { Id = Guid.Parse("10000008-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "303", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000002-D121-4CF2-A6B2-911E33DD65C5") }
                );

            context.Occupations.AddOrUpdate(o => o.Name,
                new Occupation { Name = "Porter", IsFrontOffice = true, IsBackOffice = false, Salary = 3000 },
                new Occupation { Name = "Director", IsFrontOffice = false, IsBackOffice = true, Salary = 8000 },
                new Occupation { Name = "Front Office", IsFrontOffice = true, IsBackOffice = false, Salary = 1500 },
                new Occupation { Name = "Back Office", IsFrontOffice = false, IsBackOffice = true, Salary = 1800 }
            );

            context.Employees.AddOrUpdate(e => e.Name,
                new Employee { Name = "Abraham Lincoln", Password = "Abraham Lincoln", Roles = "Porter" },
                new Employee { Name = "George Washington", Password = "George Washington", Roles = "Director" }
            );

            context.SaveChanges();
        }
    }
}
