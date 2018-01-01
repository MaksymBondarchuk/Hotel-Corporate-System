using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Corporate_System.Models.Database
{
    public class ClientAccommodation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsBooking { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }


        public Guid ClientId { get; set; }
        public Client Client { get; set; }


        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        [Display(Name = "Bill")]
        public int? BillId { get; set; }
        public Bill Bill { get; set; }
    }
}