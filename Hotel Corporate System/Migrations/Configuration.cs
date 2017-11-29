using System;
using System.Data.Entity.Migrations;
using Hotel_Corporate_System.Models;
using Hotel_Corporate_System.Models.Database;

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
				new Models.Database.Client { Id = Guid.Parse("E9C2AF99-068A-4E79-9D95-17B1C318E153"), Name = "Joe Biden", Birth = new DateTime(1942, 11, 20), IsVip = false },
				new Models.Database.Client { Id = Guid.Parse("CEDAF0F5-7328-47CE-8DF2-3D6DD3DCE83D"), Name = "Barack Obama", Birth = new DateTime(1961, 08, 04), IsVip = false },
				new Models.Database.Client { Id = Guid.Parse("37E62D04-4304-4B21-B089-52B644D6E05C"), Name = "Donald Trump", Birth = new DateTime(1946, 06, 14), IsVip = true },
				new Models.Database.Client { Id = Guid.Parse("5C1BB475-F10C-4756-B87A-97E67FCFB261"), Name = "Hillary Clinton", Birth = new DateTime(1947, 10, 26), IsVip = false },
				new Models.Database.Client { Id = Guid.Parse("0987B881-DC0C-4C58-895A-AB8438D55912"), Name = "Bernie Sanders", Birth = new DateTime(1941, 09, 08), IsVip = false }
				);

			context.Bills.AddOrUpdate(b => b.Id,
				new Models.Database.Bill { Id = Guid.Parse("A2884587-D121-4CF2-A6B2-911E33DD65C5"), Amount = 100, ClientId = Guid.Parse("37E62D04-4304-4B21-B089-52B644D6E05C") },
				new Models.Database.Bill { Id = Guid.Parse("0EF63CB9-E548-4C73-A1FE-38835A5893B0"), Amount = 360, ClientId = Guid.Parse("37E62D04-4304-4B21-B089-52B644D6E05C") },
				new Models.Database.Bill { Id = Guid.Parse("D86E1B04-38D7-4255-B33B-D34902C4B5AE"), Amount = 666, ClientId = Guid.Parse("5C1BB475-F10C-4756-B87A-97E67FCFB261") },
				new Models.Database.Bill { Id = Guid.Parse("906CCD55-D12A-4EA2-896C-A8E96E702867"), Amount = 50, ClientId = Guid.Parse("E9C2AF99-068A-4E79-9D95-17B1C318E153") },
				new Models.Database.Bill { Id = Guid.Parse("24F87F34-219A-4001-A396-338CE7C030AE"), Amount = 1500, ClientId = Guid.Parse("0987B881-DC0C-4C58-895A-AB8438D55912") }
				);

			context.Floors.AddOrUpdate(f => f.Id,
				new Models.Database.Floor { Id = Guid.Parse("00000000-D121-4CF2-A6B2-911E33DD65C5"), Number = 1 },
				new Models.Database.Floor { Id = Guid.Parse("00000001-D121-4CF2-A6B2-911E33DD65C5"), Number = 2 },
				new Models.Database.Floor { Id = Guid.Parse("00000002-D121-4CF2-A6B2-911E33DD65C5"), Number = 3 }
				);

			context.Rooms.AddOrUpdate(f => f.Id,
				new Models.Database.Room { Id = Guid.Parse("10000000-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "101", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000000-D121-4CF2-A6B2-911E33DD65C5") },
				new Models.Database.Room { Id = Guid.Parse("10000001-D121-4CF2-A6B2-911E33DD65C5"), Class = 2, Number = "102", Beds = 2, Cost = 180, FloorId = Guid.Parse("00000000-D121-4CF2-A6B2-911E33DD65C5") },
				new Models.Database.Room { Id = Guid.Parse("10000002-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "103", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000000-D121-4CF2-A6B2-911E33DD65C5") },
				new Models.Database.Room { Id = Guid.Parse("10000003-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "201", Beds = 1, Cost = 350, FloorId = Guid.Parse("00000001-D121-4CF2-A6B2-911E33DD65C5") },
				new Models.Database.Room { Id = Guid.Parse("10000004-D121-4CF2-A6B2-911E33DD65C5"), Class = 3, Number = "202", Beds = 1, Cost = 130, FloorId = Guid.Parse("00000001-D121-4CF2-A6B2-911E33DD65C5") },
				new Models.Database.Room { Id = Guid.Parse("10000005-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "203", Beds = 3, Cost = 250, FloorId = Guid.Parse("00000001-D121-4CF2-A6B2-911E33DD65C5") },
				new Models.Database.Room { Id = Guid.Parse("10000006-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "301", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000002-D121-4CF2-A6B2-911E33DD65C5") },
				new Models.Database.Room { Id = Guid.Parse("10000007-D121-4CF2-A6B2-911E33DD65C5"), Class = 2, Number = "302", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000002-D121-4CF2-A6B2-911E33DD65C5") },
				new Models.Database.Room { Id = Guid.Parse("10000008-D121-4CF2-A6B2-911E33DD65C5"), Class = 1, Number = "303", Beds = 1, Cost = 250, FloorId = Guid.Parse("00000002-D121-4CF2-A6B2-911E33DD65C5") }
				);

			//context.ClientAccommodations.AddOrUpdate(ca => ca.Id,
			//	new Models.ClientAccommodation { Id = Guid.Parse("20000000-D121-4CF2-A6B2-911E33DD65C5"), Begin = new DateTime(2017, 11, 20)}
			//	);

			context.Occupations.AddOrUpdate(o => o.Name,
				new Models.Database.Occupation { Name = "Porter", IsFrontOffice = true, IsBackOffice = false, Salary = 3000 },
				new Models.Database.Occupation { Name = "Director", IsFrontOffice = false, IsBackOffice = true, Salary = 8000 },
				new Models.Database.Occupation { Name = "Front Office", IsFrontOffice = true, IsBackOffice = false, Salary = 1500 },
				new Models.Database.Occupation { Name = "Back Office", IsFrontOffice = false, IsBackOffice = true, Salary = 1800 }
			);

			context.Employees.AddOrUpdate(e => e.Name,
				new Models.Database.Employee { Name = "Abraham Lincoln", Password = "Abraham Lincoln", Roles = "Porter"},
				new Models.Database.Employee { Name = "George Washington", Password = "George Washington", Roles = "Director"}
			);

			context.SaveChanges();
		}
	}
}
