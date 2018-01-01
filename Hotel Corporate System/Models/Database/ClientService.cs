using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Corporate_System.Models.Database
{
    public class ClientService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Comment { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Actual Amount")]
        public decimal ActualAmount { get; set; }


        [Display(Name = "Client")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }


        [Display(Name = "Service")]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }


        [Display(Name = "Bill")]
        public Guid BillId { get; set; }
        public Bill Bill { get; set; }
    }
}