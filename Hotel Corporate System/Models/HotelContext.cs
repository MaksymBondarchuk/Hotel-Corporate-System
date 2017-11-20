using System.Data.Entity;

namespace Hotel_Corporate_System.Models
{
    public class HotelContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ClientAccommodation> ClientAccommodations { get; set; }
        public DbSet<ClientService> ClientServices { get; set; }
    }
}