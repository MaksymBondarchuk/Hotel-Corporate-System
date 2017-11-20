using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Corporate_System.Models
{
    public class ClientAccommodation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsBooking { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }


        public Guid ClientId { get; set; }
        public Client Client { get; set; }


        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}